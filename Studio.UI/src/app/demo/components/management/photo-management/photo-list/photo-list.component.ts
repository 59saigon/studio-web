import { DatePipe, formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { Photo } from 'src/app/data/entity/Photo';
import {
    MessageResult,
    MessageResults,
} from 'src/app/data/results/MessageResult';
import { MessageView, MessageViews } from 'src/app/data/views/MessageView';
import { PhotoService } from 'src/app/demo/service/management/photo.service';
@Component({
    selector: 'app-photo-list',
    templateUrl: './photo-list.component.html',
    styleUrl: './photo-list.component.scss',
    providers: [MessageService, PhotoService, DatePipe],
})
export class PhotoListComponent implements OnInit {
    photoDialog: boolean = false;

    deletePhotoDialog: boolean = false;

    deletePhotosDialog: boolean = false;

    photos: Photo[] = [];

    photo: Photo = {} as Photo;

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
        private datePipe: DatePipe
    ) {}

    messageResults!: MessageResults<Photo>;
    messageResult!: MessageResult<Photo>;
    messageView!: MessageView<Photo>;
    messageViews!: MessageViews<Photo>;
    ngOnInit() {
        this.getListPhoto();

        this.statuses = [
            { label: 'OPEN', value: 'open' },
            { label: 'COMPLETED', value: 'completed' },
            { label: 'DELETED', value: 'deleted' },
        ];
    }
    getListPhoto() {
        this.photoService.getListData('photo', this.photo).subscribe({
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
    }

    openNew() {
        this.startDateNG = undefined
        this.endDateNG = undefined
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
        this.selectedPhotos.forEach((w) =>{
            this.photoService.deleteData('photo',w).subscribe({
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
        })
        this.selectedPhotos = [];
    }

    confirmDelete() {
        this.deletePhotoDialog = false;

        this.photoService.deleteData('photo',this.photo).subscribe({
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
                this.photoService.putData('photo',this.photo).subscribe({
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
                this.photoService.postData('photo',this.photo).subscribe({
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

    findIndexById(id: string): number {
        let index = -1;
        for (let i = 0; i < this.photos.length; i++) {
            if (this.photos[i].id.toString() === id) {
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
