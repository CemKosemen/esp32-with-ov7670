extern "C" {
    void app_main(void);
}

#include <sys/param.h>
#include "esp_camera.h"
#include "Arduino.h"
#include <string>

#define CAM_PIN_PWDN -1  //power down is not used
#define CAM_PIN_RESET -1 //software reset will be performed
#define CAM_PIN_XCLK 21
#define CAM_PIN_SIOD 26
#define CAM_PIN_SIOC 27
#define CAM_PIN_D7 35
#define CAM_PIN_D6 34
#define CAM_PIN_D5 39
#define CAM_PIN_D4 36
#define CAM_PIN_D3 19
#define CAM_PIN_D2 18
#define CAM_PIN_D1 5
#define CAM_PIN_D0 4
#define CAM_PIN_VSYNC 25
#define CAM_PIN_HREF 23
#define CAM_PIN_PCLK 22

static camera_config_t camera_config = {
    .pin_pwdn = CAM_PIN_PWDN,
    .pin_reset = CAM_PIN_RESET,
    .pin_xclk = CAM_PIN_XCLK,
    .pin_sscb_sda = CAM_PIN_SIOD,
    .pin_sscb_scl = CAM_PIN_SIOC,

    .pin_d7 = CAM_PIN_D7,
    .pin_d6 = CAM_PIN_D6,
    .pin_d5 = CAM_PIN_D5,
    .pin_d4 = CAM_PIN_D4,
    .pin_d3 = CAM_PIN_D3,
    .pin_d2 = CAM_PIN_D2,
    .pin_d1 = CAM_PIN_D1,
    .pin_d0 = CAM_PIN_D0,
    .pin_vsync = CAM_PIN_VSYNC,
    .pin_href = CAM_PIN_HREF,
    .pin_pclk = CAM_PIN_PCLK,

    .xclk_freq_hz = 20000000,
    .ledc_timer = LEDC_TIMER_0,
    .ledc_channel = LEDC_CHANNEL_0,

    .pixel_format = PIXFORMAT_RGB888,
    .frame_size = FRAMESIZE_QQVGA,

    .jpeg_quality = 0,
    .fb_count = 1
};

void send_img_serial(uint8_t *data, size_t len)
{
    Serial.write(data, len);
    Serial.flush();
}

esp_err_t camera_capture()
{
    camera_fb_t *fb = esp_camera_fb_get(); //acquire a frame

    if (!fb) { return ESP_FAIL; }
        
    send_img_serial(fb->buf, fb->len);

    esp_camera_fb_return(fb);
    return ESP_OK;
}

void app_main()
{
    Serial.begin(115200);
    
    esp_err_t err = esp_camera_init(&camera_config);
    if (err != ESP_OK)
    {
        Serial.println("Camera init failed.");
        exit(0);
    }

    int recv_byte = 0;
    while (true)
    {
        if (Serial.available())
        {
            recv_byte = Serial.read();

            if(recv_byte == 1)
            {
                camera_capture();
            }        
        }

        delay(500);
    }
}
