import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { WishlistDto } from '../types/wishlist/WishlistDto';
import { WishlisUpdateOrCreateDto } from '../types/wishlist/WishlisUpdateOrCreateDto';

@Injectable({
  providedIn: 'root'
})

export class WishlistsService {
  private apiUrl = "http://localhost:5214/odata/Wishlists";

  constructor(private http:HttpClient) 
  { }


  public getById(userId:string):Observable<WishlistDto>
  {
    return this.http.get<WishlistDto>(this.apiUrl+"/"+userId);
  }

  public addToList(wishlist:WishlisUpdateOrCreateDto):Observable<object>
  {
    return this.http.post(this.apiUrl+"",wishlist);
  }

  public removeFromList(wishlist:WishlisUpdateOrCreateDto):Observable<object>
  {
    return this.http.put(this.apiUrl+"",wishlist);
  }

  public delete(userId:number):Observable<object>
  {
    return this.http.delete(this.apiUrl+"/"+userId); 
  }
  
}
