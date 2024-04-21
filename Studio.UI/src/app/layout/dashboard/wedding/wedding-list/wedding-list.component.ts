import { Location } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BaseComponent } from 'src/app/core/component/base/base.component';
import { WeddingGetAllQuery } from 'src/app/data/queries/weddings/WeddingQuery';
import {
  MessageResult,
  MessageResults,
} from 'src/app/data/results/messages/MessagesResult';
import { WeddingResult } from 'src/app/data/results/weddings/WeddingResult';
import { WeddingService } from 'src/app/data/services/weddings/wedding.service';
import { Constants } from 'src/app/shared/utilities/constants/Constants';

@Component({
  selector: 'app-wedding-list',
  templateUrl: './wedding-list.component.html',
  styleUrls: ['./wedding-list.component.scss'],
})
export class WeddingListComponent extends BaseComponent implements OnInit {
    constructor(
      router: Router, 
      location: Location,
      activeRoute: ActivatedRoute,
      private weddingService: WeddingService
    ) {
      super(router, location, activeRoute); 
    }

  weddingGetAllCommand: WeddingGetAllQuery = {} as WeddingGetAllQuery;

  weddings!: WeddingResult[];

  messageResut!: MessageResults<WeddingResult>;

  page: number = 1;

  count: number = 0;

  tableSize: number = 10;

  tableSizes: any = [5, 10, 15, 20];

  ngOnInit(): void {
    this.getListWedding();
  }

  getListWedding() {
    this.weddingService
      .getListData(Constants.ENTITY_WEDDING, this.weddingGetAllCommand)
      .subscribe({
        next: (response) => {
          this.messageResut = response;
          this.weddings = this.messageResut.results;
          // Handle the successful response here
        },
        error: (err) => {
          console.error('Error occurred:', err);
          // Handle the error here
        },
      });
  }

  onTableDataChange(event: any) {
    this.page = event;
    this.getListWedding();
  }

  onTableSizeChange(event: any): void {
    this.tableSize = event.target.value;
    this.page = 1;
    this.getListWedding();
  }

  openCreateWedding(){
    this.openCreate(this.router.url, Constants.ENTITY_WEDDING);
  }
}
