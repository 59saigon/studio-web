import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CityListComponent } from './city-list.component';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forChild([
		{ path: '', component: CityListComponent },
    { path: '**', redirectTo: '/notfound' }
	])],
  exports: [RouterModule]
})
export class CityListRoutingModule { }
