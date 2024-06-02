import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ServiceListComponent } from './service-list.component';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forChild([
		{ path: '', component: ServiceListComponent },
    { path: '**', redirectTo: '/notfound' }
	])],
  exports: [RouterModule]
})
export class ServiceListRoutingModule { }
