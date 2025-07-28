import { Directive, Input, OnInit, TemplateRef, ViewContainerRef } from '@angular/core';
import { UsersService } from '../services/users.service';

@Directive({
  selector: '[appHasRole]'
})
export class HasRoleDirective implements OnInit {

 // @Input() set appHasRole(roles: string[]) {

  //     if (this.usersService.hasAnyRole(roles)) {
  //    this.viewContainer.createEmbeddedView(this.templateRef);
  //  } else {
  //    this.viewContainer.clear();
  //  }

 // }

 // The required roles to display the element
  @Input() appHasRole: string[] = [];
  @Input() appHasRoleElse?: TemplateRef<any>;
  
  constructor(
    private templateRef: TemplateRef<any>,
    private viewContainer: ViewContainerRef,
    private usersService: UsersService
  ) {}

  ngOnInit(): void {
    this.updateView();
  }

  private updateView(): void {


        if (this.usersService.hasAnyRole(this.appHasRole)) {
      this.viewContainer.clear();
      this.viewContainer.createEmbeddedView(this.templateRef);
    } else if (this.appHasRoleElse) {
      this.viewContainer.clear();
      this.viewContainer.createEmbeddedView(this.appHasRoleElse);
    } else {
      this.viewContainer.clear();
    }
  }

}