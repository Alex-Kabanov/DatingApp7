
import { MembersService } from '../../_services/members.service';
import { Member, PowerUserTiers } from '../../_models/member';
import { MemberCardComponent } from '../member-card/member-card.component';
import { Subscription } from 'rxjs';
import { Component, OnInit, OnDestroy, inject } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { FormsModule } from '@angular/forms';
import { NgFor } from '@angular/common';



@Component({
  selector: 'app-member-list',
  standalone: true,
  imports: [MemberCardComponent,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatTableModule,
    MatButtonModule,
    FormsModule,NgFor],
  templateUrl: './member-list.component.html',
  styleUrl: './member-list.component.css'
})
export class MemberListComponent implements OnInit {
  private memberService = inject(MembersService);
  members: Member[] = [];
  powerUsersTiers: PowerUserTiers[] = [];
  private subscriptions: Subscription[] = [];
  displayedColumns: string[] = ['userId', 'email', 'firstName', 'lastName', 'currentTier', 'changeTier'];


  ngOnInit(): void {
    this.loadMembers();
    this.loadPowerUsers();
  }

  loadMembers () {
    this.memberService.getMembers().subscribe({
      next: members => this.members = members
    })
  }
  loadPowerUsers() {
    this.memberService.getPowerUsers().subscribe({
      next: powerUsers => this.powerUsersTiers = powerUsers
    })
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach(sub => sub.unsubscribe());
  }
  updateUserTiers(): void{

  }

}
