import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-event-service-list',
  templateUrl: './event-service-list.component.html',
  styleUrl: './event-service-list.component.scss'
})
export class EventServiceListComponent implements OnInit {
  id: string | null = null;

  constructor(private activatedRoute: ActivatedRoute) {}

  ngOnInit() {
    // Lắng nghe thay đổi của tham số 'q' trong URL
    this.activatedRoute.queryParams.subscribe(params => {
      this.id = params['q'];
      console.log('ID received:', this.id); // Xử lý id nhận được tại đây
    });
  }
}