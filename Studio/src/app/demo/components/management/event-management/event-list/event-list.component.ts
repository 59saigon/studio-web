import { DatePipe } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { City } from 'src/app/data/entity/City';
import { Country } from 'src/app/data/entity/Country';
import { EventEntity } from 'src/app/data/entity/Event';
import { Location } from 'src/app/data/entity/Location';
import { Wedding } from 'src/app/data/entity/Wedding';
import {
    MessageResults,
    MessageResult,
} from 'src/app/data/results/MessageResult';
import { MessageView, MessageViews } from 'src/app/data/views/MessageView';
import { CountryService } from 'src/app/demo/service/management/country.service';
import { EventService } from 'src/app/demo/service/management/event.service';
import { LocationService } from 'src/app/demo/service/management/location.service';
import { WeddingService } from 'src/app/demo/service/management/wedding.service';
import headerList from './headerList';

@Component({
    selector: 'app-event-list',
    templateUrl: './event-list.component.html',
    styleUrl: './event-list.component.scss',
})
export class EventListComponent implements OnInit {
    id: string = '';

    eventDialog: boolean = false;

    deleteEventDialog: boolean = false;

    deleteEventsDialog: boolean = false;

    events: EventEntity[] = [];

    event: EventEntity = {} as EventEntity;
    location: Location = {} as Location;

    startDateNG: Date;
    endDateNG: Date;

    selectedEvents: Event[] = [];
    selectedCountry: Country;
    selectedCity: City;
    selectedWedding: Wedding;

    submitted: boolean = false;

    cols: any[] = [];

    countries: Country[] = [];
    country: Country = {} as Country;

    weddings: Wedding[] = [];
    wedding: Wedding = {} as Wedding;

    cities: City[] = [];
    city: City = {} as City;

    rowsPerPageOptions = [5, 10, 20];

    constructor(
        private eventService: EventService,
        private countryService: CountryService,
        private locationService: LocationService,
        private weddingService: WeddingService,
        private activatedRoute: ActivatedRoute,
        private router: Router
    ) {}

    messageResults!: MessageResults<EventEntity>;
    messageResult!: MessageResult<EventEntity>;
    messageView!: MessageView<EventEntity>;
    messageViews!: MessageViews<EventEntity>;

    messageCountryResults!: MessageResults<Country>;
    messageCountryResult!: MessageResult<Country>;
    messageCountryView!: MessageView<Country>;
    messageCountryViews!: MessageViews<Country>;

    messageWeddingResults!: MessageResults<Wedding>;
    messageWeddingResult!: MessageResult<Wedding>;
    messageWeddingView!: MessageView<Wedding>;
    messageWeddingViews!: MessageViews<Wedding>;

    messageLocationResults!: MessageResults<Location>;
    messageLocationResult!: MessageResult<Location>;
    messageLocationView!: MessageView<Location>;
    messageLocationViews!: MessageViews<Location>;

    showDetails = false;

    statuses: any[] = [];

    _selectedColumns: any[] = [];
    ngOnInit() {
        this.getListEvent();
        this.getListCountry();
        this.getListWedding();
        this.setShowDetails();
        this.statuses = [
            { label: 'OPEN', value: 'open' },
            { label: 'COMPLETED', value: 'completed' },
            { label: 'DELETED', value: 'deleted' },
        ];

        this.cols = headerList;

        this._selectedColumns = this.cols;
        console.log(this.cols);
    }

    @Input() get selectedColumns(): any[] {
        return this._selectedColumns;
    }

    set selectedColumns(val: any[]) {
        //restore original order
        this._selectedColumns = this.cols.filter((col) => val.includes(col));
    }

    getListCityByCountryId() {
        this.cities = this.selectedCountry.cities;
        this.selectedCity = this.cities[0];
    }
    getListWedding() {
        this.weddingService.getListData('wedding', this.wedding).subscribe({
            next: (response) => {
                this.messageWeddingResults = response;
                this.weddings = this.messageWeddingResults.results;
            },
            error: (err) => {
                this.eventService.openMessageError(err);
            },
        });
    }
    getListEvent() {
        this.eventService.getListData('event', this.event).subscribe({
            next: (response) => {
                this.messageResults = response;
                this.events = this.messageResults.results;
            },
            error: (err) => {
                this.eventService.openMessageError(err);
            },
        });
    }

    getListCountry() {
        this.countryService.getListData('country', this.country).subscribe({
            next: (response) => {
                this.messageCountryResults = response;
                this.countries = this.messageCountryResults.results;
            },
            error: (err) => {
                this.eventService.openMessageError(err);
            },
        });
    }

    openNew() {
        this.selectedWedding = undefined;
        this.selectedCity = undefined;
        this.selectedCountry = undefined;
        this.location = {} as Location;
        this.event = {} as EventEntity;
        this.submitted = false;
        this.eventDialog = true;
    }

    deleteSelectedEvents() {
        this.deleteEventsDialog = true;
    }

    editEvent(event: EventEntity) {
        this.event = { ...event };
        this.location = { ...event.location };
        this.wedding = { ...event.wedding };

        this.selectedCountry = this.countries.find(
            (c) => c.id === event.location.city.country.id
        );

        this.getListCityByCountryId();

        this.selectedCity = this.cities.find(
            (c) => c.id === event.location.city.id
        );

        this.selectedWedding = this.weddings.find(
            (w) => w.id === event.wedding.id
        );

        this.eventDialog = true;
    }

    deleteEvent(event: EventEntity) {
        this.deleteEventDialog = true;
        this.event = { ...event };
    }

    confirmDeleteSelected() {
        this.deleteEventsDialog = false;
        this.selectedEvents.forEach((w) => {
            this.eventService.deleteData('event', w).subscribe({
                next: (response) => {
                    this.ngOnInit();

                    this.eventService.openMessageSuccess('Event Deleted');
                },
                error: (err) => {
                    this.eventService.openMessageError(err);
                },
            });
        });
        this.selectedEvents = [];
    }

    confirmDelete() {
        this.deleteEventDialog = false;

        this.eventService.deleteData('event', this.event).subscribe({
            next: (response) => {
                this.ngOnInit();
                this.eventService.openMessageSuccess('Event Deleted');
            },
            error: (err) => {
                this.eventService.openMessageError(err);
            },
        });

        this.event = {} as EventEntity;
        this.location = {} as Location;
    }

    hideDialog() {
        this.eventDialog = false;
        this.submitted = false;
    }

    resetData() {
        this.event = {} as EventEntity;
        this.messageResult = {} as MessageResult<EventEntity>;
        this.messageResults = {} as MessageResults<EventEntity>;
    }
    saveLocation(callback: () => void) {
        this.setLocation();

        if (this.location.locationName?.trim()) {
            if (this.location.id) {
                this.locationService
                    .putData('location', this.location)
                    .subscribe({
                        next: (response) => {
                            this.messageLocationView = response;
                            this.location = {
                                ...this.messageLocationView.view,
                            };
                            callback();
                        },
                        error: (err) => {
                            this.eventService.openMessageError(err);
                        },
                    });
            } else {
                this.locationService
                    .postData('location', this.location)
                    .subscribe({
                        next: (response) => {
                            this.messageLocationView = response;
                            this.location = {
                                ...this.messageLocationView.view,
                            };
                            callback();
                        },
                        error: (err) => {
                            this.eventService.openMessageError(err);
                        },
                    });
            }
        }
    }
    saveEvent() {
        this.submitted = true;

        this.saveLocation(() => {
            this.setEvent();

            if (this.event.eventTittle?.trim()) {
                if (this.event.id) {
                    this.eventService.putData('event', this.event).subscribe({
                        next: (response) => {
                            this.ngOnInit();
                            this.eventService.openMessageSuccess(
                                'Updated event'
                            );
                        },
                        error: (err) => {
                            this.eventService.openMessageError(err);
                        },
                    });
                } else {
                    this.eventService.postData('event', this.event).subscribe({
                        next: (response) => {
                            console.table(this.event);
                            this.ngOnInit();
                            this.eventService.openMessageSuccess('Created');
                        },
                        error: (err) => {
                            this.eventService.openMessageError(err);
                        },
                    });
                }

                this.eventDialog = false;
            }
        });
    }

    findIndexById(id: string): number {
        let index = -1;
        for (let i = 0; i < this.events.length; i++) {
            if (this.events[i].id.toString() === id) {
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

    navigateAfterSelected(event: EventEntity) {
        this.router
            .navigateByUrl('/', { skipLocationChange: true })
            .then(() => {
                this.id = event.id.toString();
                // Navigate back with new query params
                this.router.navigate(['/management/event'], {
                    queryParams: { q: event.id },
                });
            });

        this.setShowDetails();
    }

    setShowDetails() {
        this.activatedRoute.queryParams.subscribe((params) => {
            const q = params['q'];
            this.showDetails = q && q.trim() !== '';
        });
    }

    setEvent() {
        this.event.weddingId = this.selectedWedding.id;
        this.event.locationId = this.location.id;
        this.setEventBase();
    }

    setEventBase() {
        if (this.event.id) {
            this.event.lastUpdatedDate = new Date();
            this.event.lastUpdatedBy = 'User';
            this.event.isDeleted = false;
        } else {
            this.event.createdDate = new Date();
            this.event.createdBy = 'User';
            this.event.lastUpdatedDate = new Date();
            this.event.lastUpdatedBy = 'User';
            this.event.isDeleted = false;
        }
    }

    setLocation() {
        this.location.cityId = this.selectedCity.id;
        this.setLocationBase();
    }
    setLocationBase() {
        if (this.location.id) {
            this.location.lastUpdatedDate = new Date();
            this.location.lastUpdatedBy = 'User';
            this.location.isDeleted = false;
        } else {
            this.location.createdDate = new Date();
            this.location.createdBy = 'User';
            this.location.lastUpdatedDate = new Date();
            this.location.lastUpdatedBy = 'User';
            this.location.isDeleted = false;
        }
    }
}
