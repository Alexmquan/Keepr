<template>
  <div class="main-cont" v-if="profile">
    <div class="image-cont">
      <img class="cover-img mt-5 rounded" :src="profile.coverImg" alt="">
      <img class="profile-img elevation-4" :src="profile.picture" alt="">
    </div>
    <div class="d-flex justify-content-end">
      <h2>
        <i class="mdi mdi-dots-horizontal selectable me-2"></i>

      </h2>
    </div>
    <div class="text-center profile-info">
      <h2>{{ profile.name }}</h2>
      <h6>5 Vaults | 21 Keeps</h6>
    </div>



  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { accountService } from "../services/AccountService.js"
import Pop from "../utils/Pop.js"

export default {
  setup() {
    const profileId = AppState.account.id
    async function getProfile() {
      try {
        await accountService.getProfile(profileId)
      } catch (error) {
        Pop.error(error)
      }
    }
    onMounted(() => {
      getProfile()
    })
    return {
      account: computed(() => AppState.account),
      profile: computed(() => AppState.profile)
    }
  }
}
</script>

<style scoped>
.cover-img {
  width: 100%;
  height: 30vh;
  object-fit: cover;
  object-position: center;
  /* position: relative; */
}

.main-cont {
  width: 60vw;
  margin: 0px auto;
}

.profile-info {
  margin-top: 6vh;
}

.profile-img {
  height: 15vh;
  width: 15vh;
  border-radius: 50%;
  bottom: -8vh;
  left: 25vw;
  position: absolute;
  border: 2px solid white;
}

.image-cont {
  position: relative;
  width: 100%;
}
</style>
