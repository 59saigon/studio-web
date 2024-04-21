import { Location } from '@angular/common';
import { Component, Inject, OnInit, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Guid } from 'guid-typescript';
import { BaseComponent } from 'src/app/core/component/base/base.component';
import { WeddingCreateCommand } from 'src/app/data/commands/weddings/WeddingCommand';
import { WeddingService } from 'src/app/data/services/weddings/wedding.service';
import { Constants } from 'src/app/shared/utilities/constants/Constants';


@Component({
  selector: 'app-wedding-create',
  templateUrl: './wedding-create.component.html',
  styleUrls: ['./wedding-create.component.scss'],
})
export class WeddingCreateComponent extends BaseComponent implements OnInit {
  constructor(router: Router, location: Location, activeRoute: ActivatedRoute, private fb: FormBuilder) {
    super(router, location, activeRoute);
  }
  form!: FormGroup;
  weddingCreateCommand!: WeddingCreateCommand;

  weddingService = inject(WeddingService);
  ngOnInit(): void {
    this.toggleModal();
    this.form = this.fb.group({
      weddingTittle: ['', Validators.required], // Validators can be added
      weddingDescription: [''], // Optional field
      status: [''],
      startDate: ['', Validators.required], // Sample with required validator
      endDate: ['', Validators.required],
    });
  }

  onSubmit() {
    if (this.form.valid) {
      // Map form values to WeddingCreateCommand
      this.weddingCreateCommand = {
        weddingTittle: this.form.value.weddingTittle,
        weddingDescription: this.form.value.weddingDescription,
        status: this.form.value.status,
        startDate: new Date(this.form.value.startDate),
        endDate: new Date(this.form.value.endDate),
        createdBy: 'abc', // Example of a default value
        createdDate: new Date(), // Default to now
        lastUpdatedBy: 'abc',
        lastUpdatedDate: new Date(),
        isDeleted: false, // Default value
      };

      // Now you can use this.weddingCreateCommand for API calls or further processing
      this.createWedding(this.weddingCreateCommand);
      console.table(this.weddingCreateCommand);
    } else {
      console.log('Form is not valid');
    }
  }

  createWedding(data: WeddingCreateCommand) {
    this.weddingService
      .postData(Constants.ENTITY_WEDDING, data)
      .subscribe({
        next: (response) => {
          console.table(response);
          // Handle the successful response here
        },
        error: (err) => {
          console.error('Error occurred:', err);
          // Handle the error here
        },
      });
  }
}
