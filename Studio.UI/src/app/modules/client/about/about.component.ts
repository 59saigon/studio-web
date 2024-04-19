import { Component, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.scss'],
})
export class AboutComponent implements OnInit {
  currentUrl: string = '/';

  constructor(private router: Router) {
  }
  ngOnInit(): void {
    this.currentUrl = this.router.url;
  }
}
