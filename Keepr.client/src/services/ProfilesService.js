import { AppState } from '../AppState'
import { Account, Profile } from '../models/Account.js'
import { Keep } from "../models/Keep.js"
import { Vault } from "../models/Vault.js"
import { logger } from '../utils/Logger'
import { api } from './AxiosService'
class ProfilesService {
  async getProfile(profileId) {
    logger.log(profileId)
    const res = await api.get(`api/profiles/${profileId}`)
    AppState.profile = new Profile(res.data)
  }

  async getKeepsByProfileId(profileId) {
    const res = await api.get(`api/profiles/${profileId}/keeps`)
    AppState.keeps = res.data.map(k => new Keep(k))
  }
  async getVaultsByProfileId(profileId) {
    const res = await api.get(`api/profiles/${profileId}/vaults`)
    AppState.profileVaults = res.data.map(v => new Vault(v))
    logger.log("[Profile Vaults]", AppState.profileVaults)
  }
  async getVaultsByAccountId(accountId) {
    const res = await api.get(`api/profiles/${accountId}/vaults`)
    AppState.myVaults = res.data.map(v => new Vault(v))
    logger.log("[My Vaults]", AppState.myVaults)
  }
}

export const profilesService = new ProfilesService()