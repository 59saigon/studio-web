import { Location } from "@angular/common";
import { Component, AfterViewInit, ViewChild, ElementRef } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";
import { createPopper } from "@popperjs/core";
@Component({
  selector: 'app-base',
  templateUrl: './base.component.html',
  styleUrls: ['./base.component.scss']
})
export class BaseComponent implements AfterViewInit {

  protected router: Router;
  protected location: Location;
  protected activeRoute: ActivatedRoute;
  constructor(router: Router, location: Location, activeRoute: ActivatedRoute) {
    this.router = router;
    this.location = location;
    this.activeRoute = activeRoute;
  }
  @ViewChild("btnDropdownRef", { static: false }) btnDropdownRef!: ElementRef;
  @ViewChild("popoverDropdownRef", { static: false })
  popoverDropdownRef!: ElementRef;
  ngAfterViewInit() {
    createPopper(
      this.btnDropdownRef.nativeElement,
      this.popoverDropdownRef.nativeElement,
      {
        placement: "bottom-start",
      }
    );
  }

  dropdownPopoverShow = false;
  toggleDropdown(event: any) {
    event.preventDefault();
    this.dropdownPopoverShow = !this.dropdownPopoverShow; 
  }

  showModal = false;
  toggleModal() {
    this.showModal = !this.showModal;
  }

  protected _urlCurrent! : string;
  openCreate(urlCurrent: any, entity: any){
    this._urlCurrent = urlCurrent;
    this.router.navigate([`${urlCurrent}/${entity}-create`]);
  }
  closeCreate() {
    this.router.navigate(['..'], { relativeTo: this.activeRoute }); 
  }

}
