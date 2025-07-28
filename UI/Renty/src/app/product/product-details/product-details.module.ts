import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductDetailsRoutingModule } from './product-details-routing.module';
import { ProductDetailsComponent } from './product-details.component';
import { ImagesCarouselComponent } from 'src/app/Image/images-carousel/images-carousel.component';
import { AddRatingComponent } from 'src/app/rating/add-rating/add-rating.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RatingsListComponent } from 'src/app/rating/ratings-list/ratings-list.component';
import { StarsRatingsComponent } from 'src/app/stars-ratings/stars-ratings.component';



@NgModule({
  declarations: [
    ProductDetailsComponent,
    ImagesCarouselComponent,
    AddRatingComponent,
    RatingsListComponent,
StarsRatingsComponent
  ],
  imports: [
    CommonModule,
    ProductDetailsRoutingModule,
        ReactiveFormsModule,
        FormsModule
  ],
    exports: [
    StarsRatingsComponent
  ]
})
export class ProductDetailsModule { }
