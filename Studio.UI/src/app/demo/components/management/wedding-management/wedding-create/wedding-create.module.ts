import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChartModule } from 'primeng/chart';
import { MenuModule } from 'primeng/menu';
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { StyleClassModule } from 'primeng/styleclass';
import { PanelMenuModule } from 'primeng/panelmenu';
import { WeddingCreateRoutingModule } from './wedding-create-routing.module';
import { FormsModule } from '@angular/forms';
import { WeddingCreateComponent } from './wedding-create.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        ChartModule,
        MenuModule,
        TableModule,
        StyleClassModule,
        PanelMenuModule,
        ButtonModule,
        WeddingCreateRoutingModule,
    ],
    declarations: [WeddingCreateComponent]
})
export class WeddingCreateModule {}
