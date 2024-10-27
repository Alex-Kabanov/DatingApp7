import { Photo } from "./photo"

export interface Member {
    id: number
    userName: string
    age: number
    photoUrl: string
    knowAs: string
    created: Date
    lastActive: Date
    gender: string
    introduction: string
    intrests: any
    lookingFor: string
    city: string
    country: string
    photo: Photo[]
  }
