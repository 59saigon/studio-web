import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { Country } from 'src/app/data/entity/Country';
import { MessageResult, MessageResults } from 'src/app/data/results/MessageResult';
import { MessageView, MessageViews } from 'src/app/data/views/MessageView';
import { CountryService } from 'src/app/demo/service/management/country.service';

@Component({
  selector: 'app-country-list',
  templateUrl: './country-list.component.html',
  styleUrl: './country-list.component.scss',
})
export class CountryListComponent implements OnInit{
  countryDialog: boolean = false;

  deleteCountryDialog: boolean = false;

  deleteCountrysDialog: boolean = false;

  countrys: Country[] = [];

  country: Country = {} as Country;

  startDateNG: Date;
  endDateNG: Date;

  selectedCountrys: Country[] = [];

  submitted: boolean = false;

  cols: any[] = [];

  statuses: any[] = [];

  rowsPerPageOptions = [5, 10, 20];

  constructor(
      private countryService: CountryService,
      private messageService: MessageService,
      private datePipe: DatePipe
  ) {}

  messageResults!: MessageResults<Country>;
  messageResult!: MessageResult<Country>;
  messageView!: MessageView<Country>;
  messageViews!: MessageViews<Country>;
  ngOnInit() {
      this.getListCountry();
  }
  getListCountry() {
      this.countryService.getListData('country',this.country).subscribe({
          next: (response) => {
              this.messageResults = response;
              this.countrys = this.messageResults.results;
              console.table(this.countrys)
              // Handle the successful response here
          },
          error: (err) => {
              console.error('Error occurred:', err);
              // Handle the error here
          },
      });
  }

  openNew() {
      this.country = {} as Country;
      this.submitted = false;
      this.countryDialog = true;
  }

  deleteSelectedCountrys() {
      this.deleteCountrysDialog = true;
  }

  editCountry(country: Country) {
      this.country = { ...country };
      this.countryDialog = true;
  }

  deleteCountry(country: Country) {
      this.deleteCountryDialog = true;
      this.country = { ...country };
  }

  confirmDeleteSelected() {
      this.deleteCountrysDialog = false;
      console.table(this.selectedCountrys);
      this.selectedCountrys.forEach((w) => {
          this.countryService.deleteData('country',w).subscribe({
              next: (response) => {
                  // Handle the successful response here
                  this.ngOnInit();
                  this.messageService.add({
                      severity: 'success',
                      summary: 'Successful',
                      detail: 'Country Deleted',
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
      this.selectedCountrys = [];
  }

  confirmDelete() {
      this.deleteCountryDialog = false;

      this.countryService.deleteData('country',this.country).subscribe({
          next: (response) => {
              // Handle the successful response here
              this.ngOnInit();
              this.messageService.add({
                  severity: 'success',
                  summary: 'Successful',
                  detail: 'Country Deleted',
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

      this.country = {} as Country;
  }

  hideDialog() {
      this.countryDialog = false;
      this.submitted = false;
  }

  resetData() {
      this.country = {} as Country;
      this.messageResult = {} as MessageResult<Country>;
      this.messageResults = {} as MessageResults<Country>;
  }
  saveCountry() {
      this.submitted = true;

      if (this.country.countryName?.trim()) {
          if (this.country.id) {
              this.setCountry();
              this.countryService.putData('country',this.country).subscribe({
                  next: (response) => {
                      // Handle the successful response here
                      this.ngOnInit();
                      this.messageService.add({
                          severity: 'success',
                          summary: 'Successful',
                          detail: 'Country Updated',
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
              this.setCountry();
              // add and map from MessageView to MessageResult
              this.countryService.postData('country',this.country).subscribe({
                  next: (response) => {
                      this.ngOnInit();
                      this.messageService.add({
                          severity: 'success',
                          summary: 'Successful',
                          detail: 'Country Created',
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

          this.countryDialog = false;
      }
  }

  findIndexById(id: string): number {
      let index = -1;
      for (let i = 0; i < this.countrys.length; i++) {
          if (this.countrys[i].id.toString() === id) {
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

  setCountry() {
      this.setCountryBase();
  }

  setCountryBase() {
      if (this.country.id) {
        this.country.lastUpdatedDate = new Date();
          this.country.lastUpdatedBy = 'User';
          this.country.isDeleted = false;
      } else {
          this.country.createdDate = new Date();
          this.country.createdBy = 'User';
          this.country.lastUpdatedDate = new Date();
          this.country.lastUpdatedBy = 'User';
          this.country.isDeleted = false;
      }
  }
}
