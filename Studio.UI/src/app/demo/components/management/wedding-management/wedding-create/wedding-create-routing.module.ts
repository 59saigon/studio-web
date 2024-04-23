import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { WeddingCreateComponent } from './wedding-create.component';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forChild([
    { path: '', component: WeddingCreateComponent },
    { path: '**', redirectTo: '/notfound' }
])],
  exports: [RouterModule]
})
export class WeddingCreateRoutingModule { }
