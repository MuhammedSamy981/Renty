import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AreasService } from 'src/app/services/areas.service';
import { CitiesService } from 'src/app/services/cities.service';
import { CountriesService } from 'src/app/services/countries.service';
import { UsersService } from 'src/app/services/users.service';
import { AreaDto } from 'src/app/types/area/AreaDto';
import { CityDto } from 'src/app/types/city/CityDto';
import { CountryDto } from 'src/app/types/country/CountryDto';
import { AccountUpdateDto } from 'src/app/types/user/AccountUpdateDto';

@Component({
  selector: 'app-edit-account',
  templateUrl: './edit-account.component.html',
  styleUrls:[ './edit-account.component.css']
})
export class EditAccountComponent  implements OnInit {
  countries?: CountryDto[];

  cities?: CityDto[];

  areas?: AreaDto[];
  
  userId?: string;

  constructor( private usersService: UsersService,
       private countriesService:CountriesService,
          private citiesService:CitiesService,
          private areasService:AreasService,
          private router: Router
      )
  {}
  
  ngOnInit(): void {
    this.usersService.getUser().subscribe({
      next:(user)=> {
        this.userId=user.id;
        this.getCities(user.country!);
        this.getAreas(user.city!);
        this.editAccountForm.patchValue(user);
           this.editAccountForm.controls.firstName.enable();
   this.editAccountForm.controls.lastName.enable();
   this.editAccountForm.controls.email.enable(); 
   this.editAccountForm.controls.phoneNumber.enable();
   this.editAccountForm.controls.country.enable();
      },
      error:(error)=> {
        console.error('Calling API failed',error);
      },
    })



    this.countriesService.getAll().subscribe({
      next: (countries) => {
        this.countries = countries;
      },
      error: (error) => {
        console.error('Calling API failed', error);
      },
    })
  }

 
    onCountryChange(): void {
       this.getCities(this.editAccountForm.value.country!); 
        this.editAccountForm.controls.city.setValue(0); 
    }
  
    onCityChange(): void {
  
this.getAreas(this.editAccountForm.value.city!);
 this.editAccountForm.controls.area.setValue(0);
        
    }


    getCities(countryId:number):void
    {
      this.citiesService.getAllByCountryId(countryId).subscribe({
        next: (cities) => {
          this.cities = cities;
           this.editAccountForm.controls.city.enable();
          console.log(this.cities);
        },
        error: (error) => {
          console.error('Calling API failed', error);
        },
      })
    }

    getAreas(cityId: number) {
      this.areasService.getAllByCityId(cityId).subscribe({
        next: (areas) => {
          this.areas = areas;
           this.editAccountForm.controls.area.enable();
          console.log(this.areas);
        },
        error: (error) => {
          console.error('Calling API failed', error);
        },
      })
    }


    editAccountForm=new FormGroup({
        firstName: new FormControl<string>('',[
          Validators.maxLength(10),
          Validators.required
        ]),
          lastName: new FormControl<string>('',[
          Validators.maxLength(10),
          Validators.required
        ]), 
      email: new FormControl<string>('',[
        Validators.email,
        Validators.required
      ]
      ),
        phoneNumber: new FormControl<string>('',[
          Validators.required,
          Validators.minLength(11)
        ]
        ),
    
        country: new FormControl<number>(0, [
          Validators.min(1),
        ]),
        city: new FormControl<number>(0, [
          Validators.min(1),
        ]),
        area: new FormControl<number>(0, [
          Validators.min(1),
        ]),
    
      });


  EditAccount(e:Event):void{
    e.preventDefault();
    if(this.editAccountForm.invalid) 
      {return;}

      const account : AccountUpdateDto={
        id: this.userId!,
        firstName: this.editAccountForm.value.firstName!,
        lastName: this.editAccountForm.value.lastName!,
        email: this.editAccountForm.value.email!,
        phoneNumber: this.editAccountForm.value.phoneNumber!,
        countryId: this.editAccountForm.value.country!,
        cityId: this.editAccountForm.value.city!,
        areaId: this.editAccountForm.value.area!,
      }
      console.log(account)
    this.usersService.accountUpdate(account).subscribe(
      {
        next:()=>
        {
          alert("Updated successfully");
          this.router.navigateByUrl("");
      },
      error: () => {
        alert('Updated failed');
      },
      }
    )
  }
}

