import { Component, OnInit } from '@angular/core';
import { initFlowbite } from 'flowbite';
import { components } from 'src/app/core/services/common/components';
import { NavbarComponent } from 'src/app/core/services/common/navbar.component';
import { SidebarService } from 'src/app/core/services/dashboards/sidebar';
import { SidebarComponent } from "../../../core/services/common/sidebar.component";
import { SidebarItemComponent } from "../../../core/services/common/sidebar-item.component";
import { SidebarItemGroupComponent } from "../../../core/services/common/sidebar-item-group.component";
import { CommonModule } from '@angular/common';
import { RouterModule, RouterOutlet } from '@angular/router';
import { DarkThemeToggleComponent } from 'src/app/core/services/common/dark-theme-toggle.component';

@Component({
    selector: 'app-dashboard',
    standalone: true,
    templateUrl: './dashboard.component.html',
    styleUrls: ['./dashboard.component.scss'],
    imports: [
      CommonModule, RouterOutlet, RouterModule, 
      DarkThemeToggleComponent, NavbarComponent, SidebarComponent, SidebarItemComponent, SidebarItemGroupComponent]
})
export class DashboardComponent implements OnInit {
  title = 'dashboard';
  components = components;
  constructor(readonly sidebarService: SidebarService) {}

  ngOnInit(): void {
    initFlowbite();
  } 

}
