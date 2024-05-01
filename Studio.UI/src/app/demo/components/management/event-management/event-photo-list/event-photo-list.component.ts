import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Guid } from 'guid-typescript';
import { MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { EventEntity } from 'src/app/data/entity/Event';
import { Photo, PhotoGetAllQuery } from 'src/app/data/entity/Photo';
import {
    MessageResult,
    MessageResults,
} from 'src/app/data/results/MessageResult';
import { MessageView, MessageViews } from 'src/app/data/views/MessageView';
import { EventService } from 'src/app/demo/service/management/event.service';
import { PhotoService } from 'src/app/demo/service/management/photo.service';

@Component({
    selector: 'app-event-photo-list',
    templateUrl: './event-photo-list.component.html',
    styleUrl: './event-photo-list.component.scss',
    providers: [MessageService, PhotoService, EventService, DatePipe],
})
export class EventPhotoListComponent implements OnInit {
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

    startDateNG: Date;
    endDateNG: Date;

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
        private datePipe: DatePipe
    ) {}

    messageResults!: MessageResults<Photo>;
    messageResult!: MessageResult<Photo>;
    messageView!: MessageView<Photo>;
    messageViews!: MessageViews<Photo>;
    ngOnInit() {
        this.getValueInParamater();
        this.getListPhoto();
    }
    // get còn lại
    getListPhoto() {
        this.getPhotoGetAllQuery(() => {
            console.log(this.photoGetAllQuery.photoIds[0]); // underfined
            this.photoService
                .getListData('photo', this.photoGetAllQuery)
                .subscribe({
                    next: (response) => {
                        this.messageResults = response;
                        this.photos = this.messageResults.results;
                        console.log(response);
                        // Handle the successful response here
                    },
                    error: (err) => {
                        console.error('Error occurred:', err);
                        // Handle the error here
                    },
                });
        });
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
                this.assignedPhotos[i] = this.events[this.findIndexEventsById(this.id)].eventXPhotos[
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
        this.startDateNG = undefined;
        this.endDateNG = undefined;
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
        console.table(this.selectedPhotos);
        this.selectedPhotos.forEach((w) => {
            this.photoService.deleteData('photo', w).subscribe({
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

        this.photoService.deleteData('photo', this.photo).subscribe({
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

        this.photo = {} as Photo;
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
    savePhoto() {
        this.submitted = true;

        if (this.photo.url?.trim()) {
            if (this.photo.id) {
                this.setPhoto();
                this.photoService.putData('photo', this.photo).subscribe({
                    next: (response) => {
                        // Handle the successful response here
                        this.ngOnInit();
                        this.messageService.add({
                            severity: 'success',
                            summary: 'Successful',
                            detail: 'Photo Updated',
                            life: 3000,
                        });
                    },
                    error: (err) => {
                        console.error('Error occurred:', err);
                        // Handle the error here
                        this.messageService.add({
                            severity: 'error',
                            summary: 'Error',
                            detail: 'Not update',
                            life: 3000,
                        });
                    },
                });
            } else {
                this.setPhoto();
                // add and map from MessageView to MessageResult
                this.photoService.postData('photo', this.photo).subscribe({
                    next: (response) => {
                        this.ngOnInit();
                        this.messageService.add({
                            severity: 'success',
                            summary: 'Successful',
                            detail: 'Photo Created',
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

    setPhoto() {
        this.setPhotoBase();
    }

    setPhotoBase() {
        if (this.photo.id) {
            this.photo.lastUpdatedDate = new Date();
            this.photo.lastUpdatedBy = 'User';
            this.photo.isDeleted = false;
        } else {
            this.photo.createdDate = new Date();
            this.photo.createdBy = 'User';
            this.photo.lastUpdatedDate = new Date();
            this.photo.lastUpdatedBy = 'User';
            this.photo.isDeleted = false;
        }
    }
}
