import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { PopUpComponent } from '../pop-up/pop-up.component';
import { Moment } from 'src/app/models/add-moment.model';
import { MomentServiceService } from 'src/app/core/services/admin/moment/moment-service.service';
import { AddMomentComponent } from '../add-moment/add-moment.component';
@Component({
  selector: 'app-test',
  templateUrl: './test.component.html',
  styleUrls: ['./test.component.scss'],
})
export class TestComponent implements OnInit {
  moments: Moment[] = [];

  constructor(
    public dialog: MatDialog,
    private momentService: MomentServiceService
  ) {}
  ngOnInit(): void {
    this.momentService.getMoments().subscribe({
      next: (moments) => {
        this.moments = moments;
      },
      error: (response) => {
        console.log(response);
      },
    });
  }

  openDialog() {
    const dialogConfig = new MatDialogConfig();

    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;

    this.dialog.open(AddMomentComponent, dialogConfig);

    // dialogRef.afterClosed().subscribe(result => {
    //   console.log('The dialog was closed');
    //   // Làm gì đó với kết quả
    // });
  }
}
