import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './user/login/login.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { EditAccountComponent } from './user/edit-account/edit-account.component';
import { ProductsManagementComponent } from './product/products-management/products-management.component';
import { AddProductComponent } from './product/add-product/add-product.component';
import { EditProductComponent } from './product/edit-product/edit-product.component';
import { RemoveProductComponent } from './product/remove-product/remove-product.component';
import { RefuseProductComponent } from './product/refuse-product/refuse-product.component';
import { AcceptProductComponent } from './product/accept-product/accept-product.component';
import { ProductsListComponent } from './product/products-list/products-list.component';
import { SearchProductsComponent } from './product/search-products/search-products.component';
import { WishlistComponent } from './wishlist/wishlist.component';
import { KeepRatingCommentComponent } from './rating/keep-rating-comment/keep-rating-comment.component';
import { DeleteRatingCommentComponent } from './rating/delete-rating-comment/delete-rating-comment.component';
import { ResetPasswordComponent } from './user/reset-password/reset-password.component';
import { ForgotPasswordComponent } from './user/forgot-password/forgot-password.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './auth.guard';


const routes: Routes = 
[
  {
    path:"",
    component:HomeComponent,
  },
  { 
    path: 'admin',
    loadChildren: () => import('./admin/admin.module').then(m => m.AdminModule),
      canActivate: [AuthGuard],
    data: { roles: ["Admin","Manager"] }
  },
 {
  path:"user/login",
  component:LoginComponent,
},
{
  path:"user/register",
  component:RegistrationComponent,
},
{
  path:"user/editAccount",
  component:EditAccountComponent,
  canActivate: [AuthGuard],
  data: { roles: ["User"] }
},
      {
    path:"user/forgot-password",
    component:ForgotPasswordComponent
  },
    {
    path:"user/reset-password",
    component:ResetPasswordComponent
  },
  {
    path:"product",
    component:ProductsListComponent,
  },
    {
    path:"product/management",
    component:ProductsManagementComponent,
    canActivate: [AuthGuard],
    data: { roles: ["User"] }
  },
  {
    path:"product/add",
    component:AddProductComponent,
    canActivate: [AuthGuard],
    data: { roles: ["User"] }
  },
    {
    path:"product/search/:category/:area/:productName/:destination",
    component:SearchProductsComponent,
 },
  {
    path:"product/edit/:id",
    component:EditProductComponent,
    canActivate: [AuthGuard],
    data: { roles: ["User"] }
  },
  {
    path:"product/delete/:id",
    component:RemoveProductComponent,
    canActivate: [AuthGuard],
    data: { roles: ["User"] }
  },
  {
    path:"product/refuse/:id",
    component:RefuseProductComponent,
    canActivate: [AuthGuard],
    data: { roles: ["Admin","Manager"] }
  },
  {
    path:"product/accept/:id",
    component:AcceptProductComponent,
    canActivate: [AuthGuard],
    data: { roles: ["Admin","Manager"] }
  },
  {
    path:"product/:id",
    loadChildren: () => import('./product/product-details/product-details.module').then(m => m.ProductDetailsModule) 
  },
  {
    path:"wishlist",
    component:WishlistComponent,
    canActivate: [AuthGuard],
    data: { roles: ["User"] }
  }, 
  {
    path:"rating/keep/:id",
    component:KeepRatingCommentComponent,
  canActivate: [AuthGuard],
    data: { roles: ["Admin","Manager"] }
  },
  {
    path:"rating/delete/:id",
    component:DeleteRatingCommentComponent,
    canActivate: [AuthGuard],
    data: { roles: ["Admin","Manager"] }
  },


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
