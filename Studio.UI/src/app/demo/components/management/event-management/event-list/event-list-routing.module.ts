import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventListComponent } from './event-list.component';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forChild([
		{ path: '', component: EventListComponent },
    { path: '**', redirectTo: '/notfound' }
	])],
  exports: [RouterModule]
})
export class EventListRoutingModule { }
