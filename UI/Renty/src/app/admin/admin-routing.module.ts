import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsSupervisionComponent } from '../product/products-supervision/products-supervision.component';
import { ReviewRatingsCommentsComponent } from '../rating/review-ratings-comments/review-ratings-comments.component';
import { CategoriesManagementComponent } from '../category/categories-management/categories-management.component';
import { CountriesManagementComponent } from '../country/countries-management/countries-management.component';
import { AreasManagementComponent } from '../area/areas-management/areas-management.component';
import { CitiesManagementComponent } from '../city/cities-management/cities-management.component';
import { AuthGuard } from '../auth.guard';

const routes: Routes = [

    {
      path:"",
      component:ProductsSupervisionComponent,
    },
        {
      path:"review",
      component:ReviewRatingsCommentsComponent,
      
    },
        {
      path:"category",
      component:CategoriesManagementComponent,
            canActivate: [AuthGuard],
          data: { roles: ["Manager"] }
    },
        {
      path:"country",
      component:CountriesManagementComponent,
            canActivate: [AuthGuard],
          data: { roles: ["Manager"] }
    },
        {
      path:"city",
      component:CitiesManagementComponent,
            canActivate: [AuthGuard],
          data: { roles: ["Manager"] }
    },
        {
      path:"area",
      component:AreasManagementComponent,
            canActivate: [AuthGuard],
          data: { roles: ["Manager"] }
    },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
