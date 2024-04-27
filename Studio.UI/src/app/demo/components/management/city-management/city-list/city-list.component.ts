import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { City } from 'src/app/data/entity/City';
import { Country } from 'src/app/data/entity/Country';
import {
    MessageResults,
    MessageResult,
} from 'src/app/data/results/MessageResult';
import { MessageView, MessageViews } from 'src/app/data/views/MessageView';
import { CityService } from 'src/app/demo/service/management/city.service';
import { CountryService } from 'src/app/demo/service/management/country.service';

@Component({
    selector: 'app-city-list',
    templateUrl: './city-list.component.html',
    styleUrl: './city-list.component.scss',
    providers: [MessageService, CityService, CountryService, DatePipe],
})
export class CityListComponent implements OnInit {
    cityDialog: boolean = false;

    deleteCityDialog: boolean = false;

    deleteCitysDialog: boolean = false;

    citys: City[] = [];

    city: City = {} as City;

    startDateNG: Date;
    endDateNG: Date;

    selectedCitys: City[] = [];
    selectedCountry: Country;

    submitted: boolean = false;

    cols: any[] = [];

    countries: Country[] = [];
    country: Country = {} as Country;

    rowsPerPageOptions = [5, 10, 20];

    constructor(
        private cityService: CityService,
        private messageService: MessageService,
        private countryService: CountryService,
        private datePipe: DatePipe
    ) {}

    messageResults!: MessageResults<City>;
    messageResult!: MessageResult<City>;
    messageView!: MessageView<City>;
    messageViews!: MessageViews<City>;

    messageCountryResults!: MessageResults<Country>;
    messageCountryResult!: MessageResult<Country>;
    messageCountryView!: MessageView<Country>;
    messageCountryViews!: MessageViews<Country>;
    ngOnInit() {
        this.getListCity();
        this.getListCountry();
    }
    getListCity() {
        this.cityService.getListData('city', this.city).subscribe({
            next: (response) => {
                this.messageResults = response;
                this.citys = this.messageResults.results;
                console.table(this.citys);
                // Handle the successful response here
            },
            error: (err) => {
                console.error('Error occurred:', err);
                // Handle the error here
            },
        });
    }

    getListCountry() {
        this.countryService.getListData('country', this.country).subscribe({
            next: (response) => {
                this.messageCountryResults = response;
                this.countries = this.messageCountryResults.results;
                // Handle the successful response here
            },
            error: (err) => {
                console.error('Error occurred:', err);
                // Handle the error here
            },
        });
    }

    openNew() {
        this.city = {} as City;
        this.submitted = false;
        this.cityDialog = true;
    }

    deleteSelectedCitys() {
        this.deleteCitysDialog = true;
    }

    editCity(city: City) {
        this.city = { ...city };
        this.cityDialog = true;
    }

    deleteCity(city: City) {
        this.deleteCityDialog = true;
        this.city = { ...city };
    }

    confirmDeleteSelected() {
        this.deleteCitysDialog = false;
        console.table(this.selectedCitys);
        this.selectedCitys.forEach((w) => {
            this.cityService.deleteData('city', w).subscribe({
                next: (response) => {
                    // Handle the successful response here
                    this.ngOnInit();
                    this.messageService.add({
                        severity: 'success',
                        summary: 'Successful',
                        detail: 'City Deleted',
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
        this.selectedCitys = [];
    }

    confirmDelete() {
        this.deleteCityDialog = false;

        this.cityService.deleteData('city', this.city).subscribe({
            next: (response) => {
                // Handle the successful response here
                this.ngOnInit();
                this.messageService.add({
                    severity: 'success',
                    summary: 'Successful',
                    detail: 'City Deleted',
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

        this.city = {} as City;
    }

    hideDialog() {
        this.cityDialog = false;
        this.submitted = false;
    }

    resetData() {
        this.city = {} as City;
        this.messageResult = {} as MessageResult<City>;
        this.messageResults = {} as MessageResults<City>;
    }
    saveCity() {
        this.submitted = true;

        if (this.city.cityName?.trim()) {
            if (this.city.id) {
                this.setCity();
                this.cityService.putData('city', this.city).subscribe({
                    next: (response) => {
                        // Handle the successful response here
                        this.ngOnInit();
                        this.messageService.add({
                            severity: 'success',
                            summary: 'Successful',
                            detail: 'City Updated',
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
                this.setCity();
                // add and map from MessageView to MessageResult
                this.cityService.postData('city', this.city).subscribe({
                    next: (response) => {
                        this.ngOnInit();
                        this.messageService.add({
                            severity: 'success',
                            summary: 'Successful',
                            detail: 'City Created',
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

            this.cityDialog = false;
        }
    }

    findIndexById(id: string): number {
        let index = -1;
        for (let i = 0; i < this.citys.length; i++) {
            if (this.citys[i].id.toString() === id) {
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

    setCity() {
        this.city.countryId = this.selectedCountry.id;
        this.setCityBase();
    }

    setCityBase() {
        if (this.city.id) {
            this.city.lastUpdatedBy = 'User';
            this.city.isDeleted = false;
        } else {
            this.city.createdDate = new Date();
            this.city.createdBy = 'User';
            this.city.lastUpdatedDate = new Date();
            this.city.lastUpdatedBy = 'User';
            this.city.isDeleted = false;
        }
    }
}
