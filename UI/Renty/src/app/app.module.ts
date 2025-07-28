import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { DatePipe } from '@angular/common';
import { AuthInterceptor } from './interceptors/auth.interceptor';
import { RegistrationComponent } from './user/registration/registration.component';
import { EditAccountComponent } from './user/edit-account/edit-account.component';
import { LoginComponent } from './user/login/login.component';
import { ProductsManagementComponent } from './product/products-management/products-management.component';
import { AddProductComponent } from './product/add-product/add-product.component';
import { EditProductComponent } from './product/edit-product/edit-product.component';
import { ProductsListComponent } from './product/products-list/products-list.component';
import { AcceptProductComponent } from './product/accept-product/accept-product.component';
import { RefuseProductComponent } from './product/refuse-product/refuse-product.component';
import { RemoveProductComponent } from './product/remove-product/remove-product.component';
import { AppRoutingModule } from './app-routing.module';
import { ProductsFiltersComponent } from './product/products-filters/products-filters.component';
import { SearchProductsComponent } from './product/search-products/search-products.component';
import { WishlistComponent } from './wishlist/wishlist.component';
import { KeepRatingCommentComponent } from './rating/keep-rating-comment/keep-rating-comment.component';
import { DeleteRatingCommentComponent } from './rating/delete-rating-comment/delete-rating-comment.component';
import { ForgotPasswordComponent } from './user/forgot-password/forgot-password.component';
import { ResetPasswordComponent } from './user/reset-password/reset-password.component';
import { HomeComponent } from './home/home.component';
import { AdminModule } from './admin/admin.module';
import { ProductDetailsModule } from './product/product-details/product-details.module';

@NgModule({
  declarations: [
    AppComponent,
    RegistrationComponent,
    EditAccountComponent,
    LoginComponent,
    ProductsManagementComponent,
    AddProductComponent,
    EditProductComponent,
    RemoveProductComponent,
    ProductsListComponent,
    ProductsFiltersComponent,
    AcceptProductComponent,
    RefuseProductComponent,
    SearchProductsComponent,
    WishlistComponent,
    KeepRatingCommentComponent,
    DeleteRatingCommentComponent,
    ForgotPasswordComponent,
    ResetPasswordComponent,
    HomeComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    AdminModule,
    ProductDetailsModule
  ],
  providers: [
    DatePipe,
    { 
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true 
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }