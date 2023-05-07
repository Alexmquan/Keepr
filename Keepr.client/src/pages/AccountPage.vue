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
      <h6>5 Vaults | {{ keeps.length }} Keeps</h6>
    </div>
    <!-- SECTION  VAULTS-->
    <div>
      <h2>Vaults</h2>
      <div></div>
    </div>
    <!-- SECTION Keeps -->
    <div class="mt-4">
      <h2>Keeps</h2>
      <div>
        <div class="card card-style mb-5 rounded selectable" v-for="k in keeps" :id="k.id">
          <KeepCard :keep="k" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue'
import { AppState } from '../AppState'
import { accountService } from "../services/AccountService.js"
import Pop from "../utils/Pop.js"
import { useRoute } from "vue-router"
import { profilesService } from "../services/ProfilesService.js"


export default {
  setup() {
    const route = useRoute()
    async function getProfile() {
      try {
        const profileId = route.params.profileId
        await profilesService.getProfile(profileId)
      } catch (error) {
        Pop.error(error)
      }
    }

    async function getKeepsByProfileId() {
      try {
        const profileId = route.params.profileId

        // logger.log('[Get postby id]', profileId)
        await profilesService.getKeepsByProfileId(profileId)
      } catch (error) {
        logger.log(error.message)
        Pop.error(error.message)
      }
    }
    onMounted(() => {
      getProfile()
      getKeepsByProfileId()
    })
    return {
      account: computed(() => AppState.account),
      profile: computed(() => AppState.profile),
      keeps: computed(() => AppState.keeps)
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
