import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApiService } from '../api.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-items',
  templateUrl: './items.component.html',
  styleUrls: ['./items.component.css'],
  imports:[CommonModule],
  standalone:true
})
export class ItemsComponent implements OnInit {
  items: any[] = [];

  constructor(private apiService: ApiService, private router: Router, private toastr: ToastrService) {

  }

  ngOnInit() {
    this.apiService.getAllItems().subscribe(data => {
      this.items = data;
    },
    error => {
      this.toastr.error(`The application encountered an error! Error Status: ${error.status}`);
    });
  }

  navigateToAddNewItem() {
    // Assuming you have a unique identifier for the new item
    const newItemId = '0'; // Replace this with your logic to generate a new item ID
    this.router.navigate(['/items', newItemId]);
  }

  editItem(item: any) {
    this.router.navigate(['/items', item.id]);
  }
}
