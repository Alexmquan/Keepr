<template>
  <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header no-border">

          <!-- SECTION MODAL HEADER -->

          <h1 class="modal-title fs-2 mt-3" id="exampleModalLabel">
            <slot name='header'></slot>
          </h1>
          <button title="Close" type="button" class="btn-close btn-light" data-bs-dismiss="modal"
            aria-label="Close"></button>
        </div>

        <!-- SECTION MODAL BODY -->
        <div class="modal-body text-dark">
          <slot name="body"></slot>
        </div>
        <!-- <div class="modal-footer"> -->
        <!-- <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button> -->
        <!-- <button type="button" class="btn btn-primary">Save changes</button> -->
        <!-- </div> -->
      </div>
    </div>
  </div>
</template>


<script>


export default {
  setup() {

    return {
    }
  }
}
</script>


<style lang="scss" scoped>
.no-border {
  border: white;
  align-items: normal;
}
</style>