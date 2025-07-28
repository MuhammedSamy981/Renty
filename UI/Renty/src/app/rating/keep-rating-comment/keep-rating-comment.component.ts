import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RatingsService } from 'src/app/services/ratings.service';

@Component({
  selector: 'app-keep-rating-comment',
  templateUrl: './keep-rating-comment.component.html',
  styleUrls: ['./keep-rating-comment.component.css']
})
export class KeepRatingCommentComponent implements OnInit {
  ratingId?: number;

   constructor(private ratingsService:RatingsService,
      private activatedRoute:ActivatedRoute,
      private router:Router){}
   
     ngOnInit(): void {
       this.activatedRoute.paramMap.subscribe({
         next:(map)=> {
           this.ratingId=+map.get('id')!;
      this.ratingsService.reportComment(this.ratingId,false).subscribe({
        next:()=> {
          console.log("Accept rating successfully");
          this.router.navigateByUrl("/admin/review");
        },
        error:(error)=>{
          console.error('Calling API failed',error);
        },
      })
          },
    error:(error)=> {
      console.error('This service was not found',error);
    },
  })
     }
    }