import {
  Component,
  HostBinding,
  HostListener,
  OnInit,
  Renderer2,
} from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { filter } from 'rxjs/operators';
import {
  trigger,
  state,
  style,
  transition,
  animate,
} from '@angular/animations';
@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
  animations: [
    trigger('fadeInOut', [
      transition('hidden => visible', [
        style({ transform: 'translate3d(0, -100%, 0)', opacity: 0 }),
        animate('0.4s ease', style({ transform: 'none', opacity: 1 })),
      ]),
      transition('visible => hidden', [
        animate(
          '0.4s ease',
          style({ transform: 'translate3d(0, -100%, 0)', opacity: 0 })
        ),
      ]),
    ]),
  ],
})
export class NavbarComponent implements OnInit {
  currentUrl: string = '/';
  isFixed = false;
  isSearchExpanded = false;
  isMenuExpanded = false;
  constructor(private router: Router) {}

  ngOnInit(): void {
    this.router.events
      .pipe(filter((event) => event instanceof NavigationEnd))
      .subscribe((event) => {
        if (event instanceof NavigationEnd) {
          this.currentUrl = event.url;
        }
      });
  }
  @HostListener('window:scroll', [])
  onWindowScroll(): void {
    const offset =
      window.pageYOffset ||
      document.documentElement.scrollTop ||
      document.body.scrollTop ||
      0;
    this.isFixed = offset > 100;
  }

  toggleSearch() {
    this.isSearchExpanded = !this.isSearchExpanded; // true
    if (this.isSearchExpanded) {
      this.isMenuExpanded = false;
    } else {
      this.isMenuExpanded = true;
    }
  }

  toggleMenu() {
    this.isMenuExpanded = !this.isMenuExpanded;
    if (this.isMenuExpanded) {
      this.isSearchExpanded = false;
    } else {
      this.isSearchExpanded = true;
    }
  }
}
