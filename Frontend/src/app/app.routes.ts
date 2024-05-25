import { Routes } from '@angular/router';
import { ItemsComponent } from './items/items.component';
import { ItemDetailsComponent } from './item-details/item-details.component';

export const routes: Routes = [{ path: '', redirectTo: '/items', pathMatch: 'full' },
{ path: 'items', component: ItemsComponent },
{ path: 'items/:id', component: ItemDetailsComponent },
{ path: '**', redirectTo: '/items' }];
