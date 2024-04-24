import { DatePipe, formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { Service } from 'src/app/data/entity/Service';
import {
    MessageResult,
    MessageResults,
} from 'src/app/data/results/MessageResult';
import { MessageView, MessageViews } from 'src/app/data/views/MessageView';
import { ServiceService } from 'src/app/demo/service/management/service.service';
@Component({
    selector: 'app-service-list',
    templateUrl: './service-list.component.html',
    styleUrl: './service-list.component.scss',
    providers: [MessageService, ServiceService, DatePipe],
})
export class ServiceListComponent implements OnInit {
    serviceDialog: boolean = false;

    deleteServiceDialog: boolean = false;

    deleteServicesDialog: boolean = false;

    services: Service[] = [];

    service: Service = {} as Service;

    startDateNG: Date;
    endDateNG: Date;

    selectedServices: Service[] = [];

    submitted: boolean = false;

    cols: any[] = [];

    statuses: any[] = [];

    rowsPerPageOptions = [5, 10, 20];

    constructor(
        private serviceService: ServiceService,
        private messageService: MessageService,
        private datePipe: DatePipe
    ) {}

    messageResults!: MessageResults<Service>;
    messageResult!: MessageResult<Service>;
    messageView!: MessageView<Service>;
    messageViews!: MessageViews<Service>;
    ngOnInit() {
        this.getListService();

        this.cols = [
            { field: 'service', header: 'Service' },
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
    getListService() {
        this.serviceService.getListData('service',this.service).subscribe({
            next: (response) => {
                this.messageResults = response;
                this.services = this.messageResults.results;
                console.table(this.services)
                // Handle the successful response here
            },
            error: (err) => {
                console.error('Error occurred:', err);
                // Handle the error here
            },
        });
    }

    openNew() {
        this.service = {} as Service;
        this.submitted = false;
        this.serviceDialog = true;
    }

    deleteSelectedServices() {
        this.deleteServicesDialog = true;
    }

    editService(service: Service) {
        this.service = { ...service };
        this.serviceDialog = true;
    }

    deleteService(service: Service) {
        this.deleteServiceDialog = true;
        this.service = { ...service };
    }

    confirmDeleteSelected() {
        this.deleteServicesDialog = false;
        console.table(this.selectedServices);
        this.selectedServices.forEach((w) => {
            this.serviceService.deleteData('service',w).subscribe({
                next: (response) => {
                    // Handle the successful response here
                    this.ngOnInit();
                    this.messageService.add({
                        severity: 'success',
                        summary: 'Successful',
                        detail: 'Service Deleted',
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
        this.selectedServices = [];
    }

    confirmDelete() {
        this.deleteServiceDialog = false;

        this.serviceService.deleteData('service',this.service).subscribe({
            next: (response) => {
                // Handle the successful response here
                this.ngOnInit();
                this.messageService.add({
                    severity: 'success',
                    summary: 'Successful',
                    detail: 'Service Deleted',
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

        this.service = {} as Service;
    }

    hideDialog() {
        this.serviceDialog = false;
        this.submitted = false;
    }

    resetData() {
        this.service = {} as Service;
        this.messageResult = {} as MessageResult<Service>;
        this.messageResults = {} as MessageResults<Service>;
    }
    saveService() {
        this.submitted = true;

        if (this.service.serviceTittle?.trim()) {
            if (this.service.id) {
                this.setService();
                this.serviceService.putData('service',this.service).subscribe({
                    next: (response) => {
                        // Handle the successful response here
                        this.ngOnInit();
                        this.messageService.add({
                            severity: 'success',
                            summary: 'Successful',
                            detail: 'Service Updated',
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
                this.setService();
                // add and map from MessageView to MessageResult
                this.serviceService.postData('service',this.service).subscribe({
                    next: (response) => {
                        this.ngOnInit();
                        this.messageService.add({
                            severity: 'success',
                            summary: 'Successful',
                            detail: 'Service Created',
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

            this.serviceDialog = false;
        }
    }

    findIndexById(id: string): number {
        let index = -1;
        for (let i = 0; i < this.services.length; i++) {
            if (this.services[i].id.toString() === id) {
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

    setService() {
        this.setServiceBase();
    }

    setServiceBase() {
        if (this.service.id) {
            this.service.lastUpdatedBy = 'User';
            this.service.isDeleted = false;
        } else {
            this.service.createdDate = new Date();
            this.service.createdBy = 'User';
            this.service.lastUpdatedDate = new Date();
            this.service.lastUpdatedBy = 'User';
            this.service.isDeleted = false;
        }
    }

  
}
