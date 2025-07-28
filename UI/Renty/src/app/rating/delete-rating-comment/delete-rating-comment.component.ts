import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { RatingsService } from 'src/app/services/ratings.service';

@Component({
  selector: 'app-delete-rating-comment',
  templateUrl: './delete-rating-comment.component.html',
  styleUrls: ['./delete-rating-comment.component.css']
})
export class DeleteRatingCommentComponent implements OnInit {
  ratingId?: number;

   constructor(private ratingsService:RatingsService,
      private activatedRoute:ActivatedRoute,
      private router:Router){}
   
     ngOnInit(): void {
       this.activatedRoute.paramMap.subscribe({
         next:(map)=> {
           this.ratingId=+map.get('id')!;
      this.ratingsService.removeComment(this.ratingId).subscribe({
        next:()=> {
          console.log("rmove rating successfully");
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