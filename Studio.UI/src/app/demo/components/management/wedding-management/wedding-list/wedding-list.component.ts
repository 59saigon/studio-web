import { DatePipe, formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { Wedding } from 'src/app/data/entity/Wedding';
import {
    MessageResult,
    MessageResults,
} from 'src/app/data/results/MessageResult';
import { MessageView, MessageViews } from 'src/app/data/views/MessageView';
import { WeddingService } from 'src/app/demo/service/management/wedding.service';
@Component({
    selector: 'app-wedding-list',
    templateUrl: './wedding-list.component.html',
    styleUrl: './wedding-list.component.scss',
    providers: [MessageService, WeddingService, DatePipe],
})
export class WeddingListComponent implements OnInit {
    weddingDialog: boolean = false;

    deleteWeddingDialog: boolean = false;

    deleteWeddingsDialog: boolean = false;

    weddings: Wedding[] = [];

    wedding: Wedding = {} as Wedding;

    startDateNG: Date;
    endDateNG: Date;

    selectedWeddings: Wedding[] = [];

    submitted: boolean = false;

    cols: any[] = [];

    statuses: any[] = [];

    rowsPerPageOptions = [5, 10, 20];

    constructor(
        private weddingService: WeddingService,
        private messageService: MessageService,
        private datePipe: DatePipe
    ) {}

    messageResults!: MessageResults<Wedding>;
    messageResult!: MessageResult<Wedding>;
    messageView!: MessageView<Wedding>;
    messageViews!: MessageViews<Wedding>;
    ngOnInit() {
        this.getListWedding();

        this.cols = [
            { field: 'wedding', header: 'Wedding' },
            { field: 'price', header: 'Price' },
            { field: 'category', header: 'Category' },
            { field: 'rating', header: 'Reviews' },
            { field: 'inventoryStatus', header: 'Status' },
        ];

        this.statuses = [
            { label: 'OPEN', value: 'open' },
            { label: 'COMPLETED', value: 'completed' },
            { label: 'DELETED', value: 'deleted' },
        ];
    }
    getListWedding() {
        this.weddingService.getListData('wedding', this.wedding).subscribe({
            next: (response) => {
                this.messageResults = response;
                this.weddings = this.messageResults.results;
                // Handle the successful response here
            },
            error: (err) => {
                console.error('Error occurred:', err);
                // Handle the error here
            },
        });
    }

    openNew() {
        this.wedding = {} as Wedding;
        this.submitted = false;
        this.weddingDialog = true;
    }

    deleteSelectedWeddings() {
        this.deleteWeddingsDialog = true;
    }

    editWedding(wedding: Wedding) {
        this.wedding = { ...wedding };

        // Config to view edit
        this.convertDateWeddingFromDbToView();
        this.weddingDialog = true;
    }

    deleteWedding(wedding: Wedding) {
        this.deleteWeddingDialog = true;
        this.wedding = { ...wedding };
    }

    confirmDeleteSelected() {
        this.deleteWeddingsDialog = false;
        console.table(this.selectedWeddings);
        this.selectedWeddings.forEach((w) =>{
            this.weddingService.deleteData('wedding',w).subscribe({
                next: (response) => {
                    // Handle the successful response here
                    this.ngOnInit();
                    this.messageService.add({
                        severity: 'success',
                        summary: 'Successful',
                        detail: 'Wedding Deleted',
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
        this.selectedWeddings = [];
    }

    confirmDelete() {
        this.deleteWeddingDialog = false;

        this.weddingService.deleteData('wedding',this.wedding).subscribe({
            next: (response) => {
                // Handle the successful response here
                this.ngOnInit();
                this.messageService.add({
                    severity: 'success',
                    summary: 'Successful',
                    detail: 'Wedding Deleted',
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
        
        this.wedding = {} as Wedding;
    }

    hideDialog() {
        this.weddingDialog = false;
        this.submitted = false;
    }

    resetData() {
        this.wedding = {} as Wedding;
        this.messageResult = {} as MessageResult<Wedding>;
        this.messageResults = {} as MessageResults<Wedding>;
    }
    saveWedding() {
        this.submitted = true;

        if (this.wedding.weddingTittle?.trim()) {
            if (this.wedding.id) {
                this.setWedding();
                this.weddingService.putData('wedding',this.wedding).subscribe({
                    next: (response) => {
                        // Handle the successful response here
                        this.ngOnInit();
                        this.messageService.add({
                            severity: 'success',
                            summary: 'Successful',
                            detail: 'Wedding Updated',
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
                this.setWedding();
                // add and map from MessageView to MessageResult
                this.weddingService.postData('wedding',this.wedding).subscribe({
                    next: (response) => {
                        this.ngOnInit();
                        this.messageService.add({
                            severity: 'success',
                            summary: 'Successful',
                            detail: 'Wedding Created',
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

            this.weddingDialog = false;
        }
    }

    findIndexById(id: string): number {
        let index = -1;
        for (let i = 0; i < this.weddings.length; i++) {
            if (this.weddings[i].id.toString() === id) {
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

    setWedding() {
        this.setWeddingBase();
        this.convertDateWeddingFromViewToDb();
    }

    setWeddingBase() {
        if (this.wedding.id) {
            this.wedding.lastUpdatedBy = 'User';
            this.wedding.isDeleted = false;
        } else {
            this.wedding.createdDate = new Date();
            this.wedding.createdBy = 'User';
            this.wedding.lastUpdatedDate = new Date();
            this.wedding.lastUpdatedBy = 'User';
            this.wedding.isDeleted = false;
        }
    }

    convertDateWeddingFromDbToView() {
        this.startDateNG = new Date(this.wedding.startDate);
        this.endDateNG = new Date(this.wedding.endDate);
    }

    convertDateWeddingFromViewToDb() {
        // Config time zone
        this.wedding.startDate = new Date(
            this.startDateNG.getTime() -
                this.startDateNG.getTimezoneOffset() * 60000
        );
        this.wedding.endDate = new Date(
            this.endDateNG.getTime() -
                this.endDateNG.getTimezoneOffset() * 60000
        );
    }
}
