import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { BadgeComponent } from './badge.component';
import { SanitizeHtmlPipe } from '../dashboards/pipes';
import { SidebarService } from '../dashboards/sidebar';

@Component({
  selector: 'flowbite-sidebar-item',
  standalone: true,
  imports: [CommonModule, RouterModule, SanitizeHtmlPipe, BadgeComponent],
  templateUrl: './sidebar-item.component.html'
})
export class SidebarItemComponent {

  @Input() icon?: string;
  @Input() link?: string;
  @Input() label?: string;

  constructor(readonly sidebarService: SidebarService) {}
}



// 6   pero antes crear pipe SanitizeHtmlPipe
