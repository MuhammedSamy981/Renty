import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RatingsService } from 'src/app/services/ratings.service';
import { RatingDto } from 'src/app/types/rating/RatingDto';

@Component({
  selector: 'app-review-ratings-comments',
  templateUrl: './review-ratings-comments.component.html',
  styleUrls: ['./review-ratings-comments.component.css']
})
export class ReviewRatingsCommentsComponent implements OnInit{

  ratings?: RatingDto[];

  currentRatingsPage:number = 1;
 sizeOfRatingsPage:number = 10;

  paginatedRatings?: RatingDto[];

  constructor(
     private ratingsService:RatingsService
    ){}

  ngOnInit(): void {
                   this.ratingsService.getAllReportedCommentsAsync().subscribe({
            next: (ratings) => {
              this.ratings = ratings;
              console.log(this.ratings);
            },
            error: (error) => {
              console.error('Calling API failed', error);
            },
          });
  }




          GetRatingsData(paginatedData: any[]) {
    this.paginatedRatings = paginatedData;
  }


  }
