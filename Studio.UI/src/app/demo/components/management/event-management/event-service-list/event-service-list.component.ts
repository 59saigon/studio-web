import { DatePipe } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Guid } from 'guid-typescript';
import { MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { EventEntity } from 'src/app/data/entity/Event';
import { EventXService } from 'src/app/data/entity/EventXService';
import { Service, ServiceGetAllQuery } from 'src/app/data/entity/Service';
import {
    MessageResult,
    MessageResults,
} from 'src/app/data/results/MessageResult';
import { MessageView, MessageViews } from 'src/app/data/views/MessageView';
import { EventService } from 'src/app/demo/service/management/event.service';
import { EventXServiceService } from 'src/app/demo/service/management/eventXService.service';
import { ServiceService } from 'src/app/demo/service/management/service.service';

@Component({
    selector: 'app-event-service-list',
    templateUrl: './event-service-list.component.html',
    styleUrl: './event-service-list.component.scss',
    providers: [MessageService, ServiceService, EventService, EventXServiceService],
})
export class EventServiceListComponent implements OnInit {
    //private subscription: Subscription = new Subscription();

    id: string | null = null;

    serviceDialog: boolean = false;

    deleteServiceDialog: boolean = false;

    deleteServicesDialog: boolean = false;

    assignedServices: Service[] = [];

    services: Service[] = [];
    events: EventEntity[] = [];

    service: Service = {} as Service;
    serviceGetAllQuery: ServiceGetAllQuery = {} as ServiceGetAllQuery;
    event: EventEntity = {} as EventEntity;

    eventXService: EventXService = {} as EventXService;

    selectedServices: Service[] = [];

    submitted: boolean = false;

    cols: any[] = [];

    statuses: any[] = [];

    rowsPerPageOptions = [5, 10, 20];

    constructor(
        private serviceService: ServiceService,
        private messageService: MessageService,
        private eventService: EventService,
        private activatedRoute: ActivatedRoute,
        private eventXServiceService: EventXServiceService,
        private datePipe: DatePipe
    ) {
    }
    // ngOnDestroy(): void {
    //     this.subscription.unsubscribe();
    // }

    messageResults!: MessageResults<Service>;
    messageResult!: MessageResult<Service>;
    messageView!: MessageView<Service>;
    messageViews!: MessageViews<Service>;
    ngOnInit() {
        // avoid override
        this.resetValue();

        this.getValueInParamater();
        this.getListService();
    }

    resetValue() {
        this.services = [];
        this.service = {} as Service;
        this.eventXService = {} as EventXService;
        this.events = [];
        this.serviceGetAllQuery = {} as ServiceGetAllQuery;
        this.assignedServices = [];
    }
    // get còn lại
    getListService() {
        //this.subscription.add(
            this.getServiceGetAllQuery(() => {
                this.serviceService
                    .getListData('service', this.serviceGetAllQuery)
                    .subscribe({
                        next: (response) => {
                            this.messageResults = response;
                            this.services = this.messageResults.results;
                            // Handle the successful response here
                        },
                        error: (err) => {
                            console.error('Error occurred:', err);
                            // Handle the error here
                        },
                    });
            })
        //);
    }
    // get ids
    getServiceGetAllQuery(callback: () => void) {
        this.serviceGetAllQuery.serviceIds = [];
        this.getListEvent(() => {
            for (
                let i = 0;
                i <
                this.events[this.findIndexEventsById(this.id)].eventXServices
                    .length;
                i++
            ) {
                this.serviceGetAllQuery.serviceIds[i] =
                    this.events[this.findIndexEventsById(this.id)].eventXServices[
                        i
                    ].service.id;
                this.assignedServices[i] =
                    this.events[this.findIndexEventsById(this.id)].eventXServices[
                        i
                    ].service;
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
        this.selectedServices.forEach((w) => {
            this.eventXServiceService
                .deleteData('evenXService', w.eventXServices)
                .subscribe({
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
        // get eventId
        this.eventXService.eventId = Guid.parse(this.id).toJSON().value;
        // get serviceId
        this.eventXService.serviceId = this.service.id;
        // get EventXService
        this.getEventXServiceByEventIdAndServiceId(() => {
            // xóa eventXService ( how to get ?)
            this.eventXServiceService
                .deleteData('eventXService', this.eventXService)
                .subscribe({
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
        this.eventXService = {} as EventXService;
        this.service = {} as Service;
    }

    getEventXServiceByEventIdAndServiceId(callback: () => void) {
        this.eventXServiceService
            .getByValueData('eventXService', this.eventXService, 'id')
            .subscribe({
                next: (response) => {
                    // Handle the successful response here
                    this.eventXService = { ...response.result };
                    if (this.eventXService.id.toString() != null) {
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
        this.serviceDialog = false;
        this.submitted = false;
    }

    resetData() {
        this.service = {} as Service;
        this.messageResult = {} as MessageResult<Service>;
        this.messageResults = {} as MessageResults<Service>;
    }
    assignService(service: Service) {
        this.service = { ...service };
        this.submitted = true;

        if (this.service.id) {
            this.setEventXService();
            this.eventXServiceService
                .postData('eventXService', this.eventXService)
                .subscribe({
                    next: (response) => {
                        // Handle the successful response here
                        this.ngOnInit();
                        this.messageService.add({
                            severity: 'success',
                            summary: 'Successful',
                            detail: 'EventXService Created',
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

    findIndexServicesById(id: Guid): number {
        let index = -1;
        for (let i = 0; i < this.services.length; i++) {
            if (this.services[i].id.toString() === id.toString()) {
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
    setEventXService() {
        this.eventXService.eventId = Guid.parse(this.id).toJSON().value;
        this.eventXService.serviceId = this.service.id;
        this.setEventXServiceBase();
    }

    setEventXServiceBase() {
        if (this.eventXService.id) {
            this.eventXService.lastUpdatedDate = new Date();
            this.eventXService.lastUpdatedBy = 'User';
            this.eventXService.isDeleted = false;
        } else {
            this.eventXService.createdDate = new Date();
            this.eventXService.createdBy = 'User';
            this.eventXService.lastUpdatedDate = new Date();
            this.eventXService.lastUpdatedBy = 'User';
            this.eventXService.isDeleted = false;
        }
    }
}
