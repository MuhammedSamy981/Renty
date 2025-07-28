import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ImageAddDto } from '../types/image/ImageAddDto';
import { ImageUpdateDto } from '../types/image/ImageUpdateDto';

@Injectable({
  providedIn: 'root'
})
export class ImagesService {

  private apiUrl = "http://localhost:5214/odata/Images";
  constructor(private http:HttpClient) {}

  public add(image:ImageAddDto):Observable<object>
  {
    return this.http.post(this.apiUrl,image);
  }

  public update(image:ImageUpdateDto):Observable<object>
  {
    return this.http.put(this.apiUrl,image);
  }
  
}
