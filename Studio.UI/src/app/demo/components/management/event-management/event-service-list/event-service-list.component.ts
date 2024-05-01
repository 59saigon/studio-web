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
  }
}