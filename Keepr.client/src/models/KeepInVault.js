import { Profile } from "./Account.js"

export class KeepInVault {
  constructor(data) {
    this.id = data.id
    this.vaultKeepId = data.vaultKeepId
    this.creatorId = data.creatorId
    this.name = data.name
    this.description = data.description
    this.img = data.img
    this.views = data.views
    this.kept = data.kept
    this.creator = new Profile(data.creator)
  }
}