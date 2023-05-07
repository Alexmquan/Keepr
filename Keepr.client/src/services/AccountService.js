import { AppState } from '../AppState'
import { Account, Profile } from '../models/Account.js'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = new Account(res.data)
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getProfile(profileId) {
    logger.log(profileId)
    const res = await api.get(`api/profiles/${profileId}`)
    AppState.profile = new Profile(res.data)
  }
}

export const accountService = new AccountService()
