import { DatePipe } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Guid } from 'guid-typescript';
import { MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { Subscription } from 'rxjs';
import { EventEntity } from 'src/app/data/entity/Event';
import { EventXPhoto } from 'src/app/data/entity/EventXPhoto';
import { Photo, PhotoGetAllQuery } from 'src/app/data/entity/Photo';
import {
    MessageResult,
    MessageResults,
} from 'src/app/data/results/MessageResult';
import { MessageView, MessageViews } from 'src/app/data/views/MessageView';
import { EventService } from 'src/app/demo/service/management/event.service';
import { EventXPhotoService } from 'src/app/demo/service/management/eventXPhoto.service';
import { PhotoService } from 'src/app/demo/service/management/photo.service';

@Component({
    selector: 'app-event-photo-list',
    templateUrl: './event-photo-list.component.html',
    styleUrl: './event-photo-list.component.scss',
    providers: [MessageService, PhotoService, EventService, EventXPhotoService],
})
export class EventPhotoListComponent implements OnInit, OnDestroy {
    private subscription: Subscription = new Subscription();

    id: string | null = null;

    photoDialog: boolean = false;

    deletePhotoDialog: boolean = false;

    deletePhotosDialog: boolean = false;

    assignedPhotos: Photo[] = [];

    photos: Photo[] = [];
    events: EventEntity[] = [];

    photo: Photo = {} as Photo;
    photoGetAllQuery: PhotoGetAllQuery = {} as PhotoGetAllQuery;
    event: EventEntity = {} as EventEntity;

    eventXPhoto: EventXPhoto = {} as EventXPhoto;

    selectedPhotos: Photo[] = [];

    submitted: boolean = false;

    cols: any[] = [];

    statuses: any[] = [];

    rowsPerPageOptions = [5, 10, 20];

    constructor(
        private photoService: PhotoService,
        private messageService: MessageService,
        private eventService: EventService,
        private activatedRoute: ActivatedRoute,
        private eventXPhotoService: EventXPhotoService,
        private datePipe: DatePipe
    ) {
        console.log('changed');
    }
    ngOnDestroy(): void {
        this.subscription.unsubscribe();
    }

    messageResults!: MessageResults<Photo>;
    messageResult!: MessageResult<Photo>;
    messageView!: MessageView<Photo>;
    messageViews!: MessageViews<Photo>;
    ngOnInit() {
        // avoid override
        this.resetValue();

        this.getValueInParamater();
        this.getListPhoto();
    }

    resetValue() {
        this.photos = [];
        this.photo = {} as Photo;
        this.eventXPhoto = {} as EventXPhoto;
        this.events = [];
        this.photoGetAllQuery = {} as PhotoGetAllQuery;
        this.assignedPhotos = [];
    }
    // get còn lại
    getListPhoto() {
        this.subscription.add(
            this.getPhotoGetAllQuery(() => {
                this.photoService
                    .getListData('photo', this.photoGetAllQuery)
                    .subscribe({
                        next: (response) => {
                            this.messageResults = response;
                            this.photos = this.messageResults.results;
                            // Handle the successful response here
                        },
                        error: (err) => {
                            console.error('Error occurred:', err);
                            // Handle the error here
                        },
                    });
            })
        );
    }
    // get ids
    getPhotoGetAllQuery(callback: () => void) {
        this.photoGetAllQuery.photoIds = [];
        this.getListEvent(() => {
            for (
                let i = 0;
                i <
                this.events[this.findIndexEventsById(this.id)].eventXPhotos
                    .length;
                i++
            ) {
                this.photoGetAllQuery.photoIds[i] =
                    this.events[this.findIndexEventsById(this.id)].eventXPhotos[
                        i
                    ].photo.id;
                this.assignedPhotos[i] =
                    this.events[this.findIndexEventsById(this.id)].eventXPhotos[
                        i
                    ].photo;
            }
            callback();
        });
    }

    getListEvent(callback: () => void) {
        this.eventService.getListData('event', this.event).subscribe({
            next: (response) => {
                this.events = response.results;
                callback();
            },
            error: (err) => {
                console.error('Error occurred:', err);
                // Handle the error here
            },
        });
    }
    // end ids
    openNew() {
        this.photo = {} as Photo;

        this.submitted = false;
        this.photoDialog = true;
    }

    deleteSelectedPhotos() {
        this.deletePhotosDialog = true;
    }

    editPhoto(photo: Photo) {
        this.photo = { ...photo };
        this.photoDialog = true;
    }

    deletePhoto(photo: Photo) {
        this.deletePhotoDialog = true;
        this.photo = { ...photo };
    }

    confirmDeleteSelected() {
        this.deletePhotosDialog = false;
        this.selectedPhotos.forEach((w) => {
            this.eventXPhotoService
                .deleteData('evenXPhoto', w.eventXPhotos)
                .subscribe({
                    next: (response) => {
                        // Handle the successful response here
                        this.ngOnInit();
                        this.messageService.add({
                            severity: 'success',
                            summary: 'Successful',
                            detail: 'Photo Deleted',
                            life: 3000,
                        });
                    },
                    error: (err) => {
                        console.error('Error occurred:', err);
                        // Handle the error here
                        this.messageService.add({
                            severity: 'error',
                            summary: 'Error',
                            detail: 'Not Delete',
                            life: 3000,
                        });
                    },
                });
        });
        this.selectedPhotos = [];
    }

    confirmDelete() {
        this.deletePhotoDialog = false;
        // get eventId
        this.eventXPhoto.eventId = Guid.parse(this.id).toJSON().value;
        // get photoId
        this.eventXPhoto.photoId = this.photo.id;
        // get EventXPhoto
        this.getEventXPhotoByEventIdAndPhotoId(() => {
            // xóa eventXPhoto ( how to get ?)
            this.eventXPhotoService
                .deleteData('eventXPhoto', this.eventXPhoto)
                .subscribe({
                    next: (response) => {
                        // Handle the successful response here
                        this.ngOnInit();
                        this.messageService.add({
                            severity: 'success',
                            summary: 'Successful',
                            detail: 'Photo Deleted',
                            life: 3000,
                        });
                    },
                    error: (err) => {
                        console.error('Error occurred:', err);
                        // Handle the error here
                        this.messageService.add({
                            severity: 'error',
                            summary: 'Error',
                            detail: 'Not Delete',
                            life: 3000,
                        });
                    },
                });
        });
        this.eventXPhoto = {} as EventXPhoto;
        this.photo = {} as Photo;
    }

    getEventXPhotoByEventIdAndPhotoId(callback: () => void) {
        this.eventXPhotoService
            .getByValueData('eventXPhoto', this.eventXPhoto, 'id')
            .subscribe({
                next: (response) => {
                    // Handle the successful response here
                    this.eventXPhoto = { ...response.result };
                    if (this.eventXPhoto.id.toString() != null) {
                        callback();
                    }
                },
                error: (err) => {
                    console.error('Error occurred:', err);
                    // Handle the error here
                    this.messageService.add({
                        severity: 'error',
                        summary: 'Error',
                        detail: 'Not Delete',
                        life: 3000,
                    });
                },
            });
    }

    hideDialog() {
        this.photoDialog = false;
        this.submitted = false;
    }

    resetData() {
        this.photo = {} as Photo;
        this.messageResult = {} as MessageResult<Photo>;
        this.messageResults = {} as MessageResults<Photo>;
    }
    assignPhoto(photo: Photo) {
        this.photo = { ...photo };
        this.submitted = true;

        if (this.photo.id) {
            this.setEventXPhoto();
            this.eventXPhotoService
                .postData('eventXPhoto', this.eventXPhoto)
                .subscribe({
                    next: (response) => {
                        // Handle the successful response here
                        this.ngOnInit();
                        this.messageService.add({
                            severity: 'success',
                            summary: 'Successful',
                            detail: 'EventXPhoto Created',
                            life: 3000,
                        });
                    },
                    error: (err) => {
                        console.error('Error occurred:', err);
                        // Handle the error here
                        this.messageService.add({
                            severity: 'error',
                            summary: 'Error',
                            detail: 'Not create',
                            life: 3000,
                        });
                    },
                });
        }
        this.photoDialog = false;
    }

    findIndexPhotosById(id: Guid): number {
        let index = -1;
        for (let i = 0; i < this.photos.length; i++) {
            if (this.photos[i].id.toString() === id.toString()) {
                index = i;
                break;
            }
        }

        return index;
    }

    findIndexEventsById(id: string): number {
        let index = -1;
        for (let i = 0; i < this.events.length; i++) {
            if (this.events[i].id.toString() === id.toString()) {
                index = i;
                break;
            }
        }

        return index;
    }

    onGlobalFilter(table: Table, event: Event) {
        table.filterGlobal(
            (event.target as HTMLInputElement).value,
            'contains'
        );
    }

    getValueInParamater() {
        this.activatedRoute.queryParams.subscribe((params) => {
            // Giả sử tham số là 'q'
            const q = params['q'];
            // Thiết lập showDetails dựa trên sự tồn tại và giá trị của 'q'
            if (q && q.trim() !== '') {
                this.id = q.toString();
            }
        });
    }
    setEventXPhoto() {
        this.eventXPhoto.eventId = Guid.parse(this.id).toJSON().value;
        this.eventXPhoto.photoId = this.photo.id;
        this.setEventXPhotoBase();
    }

    setEventXPhotoBase() {
        if (this.eventXPhoto.id) {
            this.eventXPhoto.lastUpdatedDate = new Date();
            this.eventXPhoto.lastUpdatedBy = 'User';
            this.eventXPhoto.isDeleted = false;
        } else {
            this.eventXPhoto.createdDate = new Date();
            this.eventXPhoto.createdBy = 'User';
            this.eventXPhoto.lastUpdatedDate = new Date();
            this.eventXPhoto.lastUpdatedBy = 'User';
            this.eventXPhoto.isDeleted = false;
        }
    }
}
