import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { RatingAddDto } from '../types/rating/RatingAddDto';
import { RatingDto } from '../types/rating/RatingDto';

@Injectable({
  providedIn: 'root'
})
export class RatingsService {

  private apiUrl = "http://localhost:5214/odata/Ratings";
  constructor(private http:HttpClient) { }

    public getAllReportedCommentsAsync():Observable<RatingDto[]>
    {
      return this.http.get<RatingDto[]>(this.apiUrl+"/Comments");
    }

  public getSpecificAsync(userId:string,productId:number):Observable<RatingDto>
  {
    return this.http.get<RatingDto>(this.apiUrl+"/"+userId+","+productId);
  }

  public add(rating:RatingAddDto):Observable<object>
  {
    return this.http.post(this.apiUrl,rating);
  }

    public reportComment(ratingId:number,status:boolean):Observable<object>
    {
      return this.http.put(this.apiUrl+"/Report/"+ratingId+","+status,null); 
    }

        public removeComment(ratingId:number):Observable<object>
    {
      return this.http.put(this.apiUrl+"/CommentRemove/"+ratingId,null); 
    }
  

  public delete(id:number):Observable<object>
  {
    return this.http.delete(this.apiUrl+"/"+id);
  }


}
