import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminRoutingModule } from './admin-routing.module';
import { AdminComponent } from './admin.component';
import { AddCategoryComponent } from '../category/add-category/add-category.component';
import { RemoveCategoryComponent } from '../category/remove-category/remove-category.component';
import { AddCountryComponent } from '../country/add-country/add-country.component';
import { RemoveCountryComponent } from '../country/remove-country/remove-country.component';
import { AddCityComponent } from '../city/add-city/add-city.component';
import { RemoveCityComponent } from '../city/remove-city/remove-city.component';
import { AddAreaComponent } from '../area/add-area/add-area.component';
import { RemoveAreaComponent } from '../area/remove-area/remove-area.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PaginationComponent } from '../pagination/pagination.component';
import { HasRoleDirective } from './has-role.directive';
import { CategoriesManagementComponent } from '../category/categories-management/categories-management.component';
import { CountriesManagementComponent } from '../country/countries-management/countries-management.component';
import { CitiesManagementComponent } from '../city/cities-management/cities-management.component';
import { AreasManagementComponent } from '../area/areas-management/areas-management.component';
import { ProductsSupervisionComponent } from '../product/products-supervision/products-supervision.component';
import { ReviewRatingsCommentsComponent } from '../rating/review-ratings-comments/review-ratings-comments.component';

@NgModule({
  declarations: [
    AdminComponent,
    ProductsSupervisionComponent,
    ReviewRatingsCommentsComponent,
    AddCategoryComponent,
    RemoveCategoryComponent,
    CategoriesManagementComponent,
    AddCountryComponent,
    RemoveCountryComponent,
    CountriesManagementComponent,
    AddCityComponent,
    RemoveCityComponent,
    CitiesManagementComponent,
    AddAreaComponent,
    RemoveAreaComponent,
    AreasManagementComponent,
    PaginationComponent,
    HasRoleDirective,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    ReactiveFormsModule,
    FormsModule,
  ],
    exports: [
      AdminComponent,
    PaginationComponent,
    HasRoleDirective
  ]
})
export class AdminModule { }
