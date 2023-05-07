export class Account {
  constructor(data) {

    this.email = data.email

    // TODO add additional properties if needed
  }
}

export class Profile extends Account {
  constructor(data) {
    super(data)
    this.name = data.name
    this.picture = data.picture
    this.coverImg = data.coverImg
    this.id = data.id
  }
}
