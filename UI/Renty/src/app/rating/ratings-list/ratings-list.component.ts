import { Component, EventEmitter, Input, Output } from '@angular/core';
import { RatingsService } from 'src/app/services/ratings.service';
import { RatingDto } from 'src/app/types/rating/RatingDto';

@Component({
  selector: 'app-ratings-list',
  templateUrl: './ratings-list.component.html',
  styleUrls: ['./ratings-list.component.css']
})
export class RatingsListComponent {

   @Input() ratings?:RatingDto[];
   @Input() currentUserId?:string;
   @Input() ratingId?:number;
   @Input() deletingStatus?:boolean;
   @Input() reportStatus?:boolean;

     @Output() sendUpdatedRatingId=new EventEmitter<number>();

 constructor(private ratingsService:RatingsService){}

  deleteRating() {
    this.ratingsService.delete(this.ratingId!).subscribe({
      next:()=> {
        this.deletingStatus=true;
        this.ratingId=undefined;
        this.updateRatingId();
      },
      error:(error)=> {
        console.error("Calling API failed ,this id: "+this.ratingId+"is not found",error);     
      },
    })
    }

    updateRatingId()
    {
      this.sendUpdatedRatingId.emit(this.ratingId);
    }

    reportAbuse(ratingId:number):void
    {
      this.ratingsService.reportComment(ratingId,true).subscribe({
      next:()=> {
         alert("Report succese");
      },
      error:(error)=> {
        console.error("Calling API failed ,this id: "+ratingId+"is not found",error);     
      },
    })
    }
  
}
