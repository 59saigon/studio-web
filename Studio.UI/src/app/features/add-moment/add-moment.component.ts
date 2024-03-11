import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MomentServiceService } from 'src/app/core/services/admin/moment/moment-service.service';
import { Moment } from 'src/app/models/add-moment.model';
import Swal from 'sweetalert2';
import { v4 as uuidv4 } from 'uuid';
@Component({
  selector: 'app-add-moment',
  templateUrl: './add-moment.component.html',
  styleUrls: ['./add-moment.component.scss'],
})
export class AddMomentComponent implements OnInit {
  addMomentRequest: Moment = {
    picture: '',
    date: new Date(),
    title: '',
    content: '',
    userId: this.getDefaultUserId(),
    createdBy: '',
    createdDate: new Date(),
  };
  constructor(
    public dialog: MatDialog,
    private momentService: MomentServiceService
  ) {}

  ngOnInit(): void {}
  onClose() {
    this.dialog.closeAll();
  }
  private getDefaultUserId(): string {
    // Logic để lấy userId mặc định, nếu không có sẽ trả về ''
    // Ví dụ: Giả sử bạn có một phương thức hoặc biến để lấy userId mặc định
    // Nếu không có, trả về ''
    return 'EBA2E72E-9139-4E82-A3D7-218E78CCAF31' || '';
  }
  addMoment() {
    this.momentService.createMoment(this.addMomentRequest).subscribe({
      next: (moment) => {
        console.log(moment);
        this.onClose();
        this.alertWithSuccess(this.addMomentRequest);
      },
      error: (response) => {
        console.log(response);
        this.alertWithFail(this.addMomentRequest);
      },
    });
    //console.log(this.addMomentRequest);
  }

  alertWithSuccess(moment: Moment) {
    Swal.fire(
      'Success...',
      'Tittle: ' + moment.title + ' | That Was Added Successfully',
      'success'
    );
  }
  alertWithFail(moment: Moment) {
    Swal.fire('Fail...', 'Tittle: ' + moment.title + ' | That Fail', 'error');
  }
}
