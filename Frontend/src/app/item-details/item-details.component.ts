import { Component, OnInit, Input } from '@angular/core';
import { ApiService } from '../api.service';
import { ReactiveFormsModule } from '@angular/forms';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-item-details',
  templateUrl: './item-details.component.html',
  styleUrls: ['./item-details.component.css'],
  imports: [ReactiveFormsModule],
  standalone: true
})
export class ItemDetailsComponent implements OnInit {
  @Input() id: number = 0;
  item: any;
  itemForm: FormGroup; 

  constructor(private apiService: ApiService, private router: Router, private toastr: ToastrService) {
    this.itemForm = new FormGroup({
      name: new FormControl(),
      description: new FormControl(),
      category: new FormControl()
    });
  }

  ngOnInit() {
    if (this.id != 0) {
      this.apiService.getItemById(this.id).subscribe(data => {
        this.item = data;

        this.itemForm = new FormGroup({
          id: new FormControl(this.item.id),
          name: new FormControl(this.item.name),
          description: new FormControl(this.item.description),
          category: new FormControl(this.item.category)
        });
      },
      error => {
        this.toastr.error(`The application encountered an error! Error Status: ${error.status}`);
        this.router.navigate(['/items'])
      });
    }
    else {
      this.item.id = 0;
      this.item.name = "";
      this.item.description = "";
      this.item.category = "";

      this.itemForm = new FormGroup({
        id: new FormControl(this.item.id),
        name: new FormControl(this.item.name),
        description: new FormControl(this.item.description),
        category: new FormControl(this.item.category)
      });
    }
  }

  updateItem(updatedItem: any) {
    this.apiService.updateItem(this.id, updatedItem).subscribe(() => {
      this.router.navigate(['/items'])
      this.toastr.info(`Item Saved!`);
    },
    error => {
      this.toastr.error(`The application encountered an error! Error Status: ${error.status}`);
      this.router.navigate(['/items'])

    });
  }

  addItem(addItem: any) {
    this.apiService.createItem(addItem).subscribe(() => {
      this.router.navigate(['/items'])
      this.toastr.info(`Item Added!`);
    },
    error => {
      this.toastr.error(`The application encountered an error! Error Status: ${error.status}`);
      this.router.navigate(['/items'])
    });
  }

  onSubmit() {
    // Handle form submission
    if (this.id != 0) {
      this.updateItem(this.itemForm.value);
    }
    else {
      this.addItem(this.itemForm.value);
    }
    
  }
}
