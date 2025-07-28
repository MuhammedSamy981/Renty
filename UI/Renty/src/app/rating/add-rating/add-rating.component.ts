import { Component, Input } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { RatingsService } from 'src/app/services/ratings.service';
import { RatingAddDto } from 'src/app/types/rating/RatingAddDto';

@Component({
  selector: 'app-add-rating',
  templateUrl: './add-rating.component.html',
  styleUrls: ['./add-rating.component.css']
})
export class AddRatingComponent {

  @Input() productId?:number;
  @Input() userId?:string;
  @Input() checkUserId:boolean=false;
  @Input() ratingId?:number;

  newRatingId?:number;
  fullName?:string;
  comment?:string;
  rating:number=0;
  ratingDate?:string;
  checkedStars:number[]=[5,4,3,2,1];

  AddingStatus:boolean=false;

  constructor(private ratingsService:RatingsService) { }


  ratingGroup=new FormGroup({
    rating:new FormControl<number>(0),
    comment:new FormControl<string>(''),
  })
  
  addRating():void
  {
    const rating:RatingAddDto=
    {
      productId: this.productId!,
      userId: this.userId!,
      comment: this.ratingGroup.value.comment!,
      value: this.ratingGroup.value.rating!,
    };
    this.ratingsService.add(rating).subscribe({
      next:()=> 
      {
        this.ratingsService.getSpecificAsync(this.userId!,this.productId!).subscribe({
          next:(rating)=> {
            this.newRatingId=rating.id;
            this.fullName=rating.fullName;
            this.comment= this.ratingGroup.value.comment!;
            this.rating=this.ratingGroup.value.rating!;
            this.ratingDate=rating.datetime!;
            this.AddingStatus=true;
          },
          error:(error)=> {
            console.error("Calling API failed",error);     
          },
        })
      },
      error:(err)=> {
        console.log("failed",err);
        console.log(rating.productId+"/"+rating.userId+"/"+rating.comment+"/"+rating.value+"/");
      },
    });
  }

   deleteRating() {
    this.ratingsService.delete(this.newRatingId!).subscribe({
      next:()=> {
        this.AddingStatus=false;
      },
      error:(error)=> {
        console.error("Calling API failed ,this id: "+this.newRatingId+"is not found",error);     
      },
    })
    }

    ratingChanged(event: CustomEvent<number>) {
      this.ratingGroup.value.rating=event.detail;
      console.log(event.detail+"/"+this.ratingGroup.value.rating!);
     }

}

