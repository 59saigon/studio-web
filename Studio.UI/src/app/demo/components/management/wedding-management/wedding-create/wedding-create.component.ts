import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-wedding-create',
  templateUrl: './wedding-create.component.html',
  styleUrl: './wedding-create.component.scss'
})
export class WeddingCreateComponent implements OnInit {
  ngOnInit() {
    console.log("re-run");
  }

  constructor(private router: Router){

  }

  navigateLinkButton() {
    console.log('easy-game');
    this.ngOnInit();
  }
}
