import { Injectable, Inject } from '@angular/core';
import { DOCUMENT } from '@angular/common';

import Color from 'color';

@Injectable({
  providedIn: 'root',
})
export class ThemeService {
  constructor(@Inject(DOCUMENT) private document: Document) {}

  setTheme(colors: any) {
    const cssText = CSSTextGenerator(colors);
    this.setGlobalCSS(cssText);
  }

  private setGlobalCSS(css: string) {
    this.document.documentElement.style.cssText = css;
  }
}

const defaults = {
  primary: '#5F0F40',
  secondary: '#7EA3CC',
  tertiary: '#335145',
  success: '#6DA34D',
  warning: '#FCDC4D',
  danger: '#C80428',
  dark: '#2f2f2f',
  medium: '#5f5f5f',
  light: '#f6f8fc',
};

function CSSTextGenerator(colors: any) {
  colors = { ...defaults, ...colors };
  const {
    primary,
    secondary,
    tertiary,
    success,
    warning,
    danger,
    dark,
    medium,
    light,
  } = colors;
  const shadeRatio = 0.1;
  const tintRatio = 0.1;

  return `
    --ion-color-base: ${light};
    --ion-color-contrast: ${dark};
    --ion-background-color: ${light};
    --ion-text-color: ${dark};
    --ion-toolbar-background-color: ${contrast(light)};
    --ion-toolbar-text-color: ${contrast(dark)};
    --ion-input-background-color: ${contrast(light, 0.3)};
    --ion-input-text-color: ${contrast(dark, 0.3)};

    --ion-color-primary: ${primary};
    --ion-color-primary-rgb: 95, 15, 64;
    --ion-color-primary-contrast: ${contrast(primary)};
    --ion-color-primary-contrast-rgb: 255, 255, 255;
    --ion-color-primary-shade: ${Color(primary).darken(shadeRatio)};
    --ion-color-primary-tint: ${Color(primary).lighten(tintRatio)};

    --ion-color-secondary: ${secondary};
    --ion-color-secondary-rgb: 126, 163, 204;
    --ion-color-secondary-contrast: ${contrast(secondary)};
    --ion-color-secondary-contrast-rgb: 255, 255, 255;
    --ion-color-secondary-shade: ${Color(secondary).darken(shadeRatio)};
    --ion-color-secondary-tint: ${Color(secondary).lighten(tintRatio)};

    --ion-color-tertiary: ${tertiary};
    --ion-color-tertiary-rgb: 51, 81, 69;
    --ion-color-tertiary-contrast: ${contrast(tertiary)};
    --ion-color-tertiary-contrast-rgb: 255, 255, 255;
    --ion-color-tertiary-shade: ${Color(tertiary).darken(shadeRatio)};
    --ion-color-tertiary-tint: ${Color(tertiary).lighten(tintRatio)};

    --ion-color-success: ${success};
    --ion-color-success-rgb: 109, 163, 77;
    --ion-color-success-contrast: ${contrast(success)};
    --ion-color-success-contrast-rgb: 255, 255, 255;
    --ion-color-success-shade: ${Color(success).darken(shadeRatio)};
    --ion-color-success-tint: ${Color(success).lighten(tintRatio)};

    --ion-color-warning: ${warning};
    --ion-color-warning-rgb: 252, 220, 77;
    --ion-color-warning-contrast: ${contrast(warning)};
    --ion-color-warning-contrast-rgb: 255, 255, 255;
    --ion-color-warning-shade: ${Color(warning).darken(shadeRatio)};
    --ion-color-warning-tint: ${Color(warning).lighten(tintRatio)};
    
    --ion-color-danger: ${danger};
    --ion-color-danger-rgb: 200, 4, 40;
    --ion-color-danger-contrast: ${contrast(danger)};
    --ion-color-danger-contrast-rgb: 255, 255, 255;
    --ion-color-danger-shade: ${Color(danger).darken(shadeRatio)};
    --ion-color-danger-tint: ${Color(danger).lighten(tintRatio)};
    
    --ion-color-dark: ${dark};
    --ion-color-dark-rgb: 47, 47, 47;
    --ion-color-dark-contrast: ${contrast(dark)};
    --ion-color-dark-contrast-rgb: 255, 255, 255;
    --ion-color-dark-shade: ${Color(dark).darken(shadeRatio)};
    --ion-color-dark-tint: ${Color(dark).lighten(tintRatio)};
    
    --ion-color-medium: ${medium};
    --ion-color-medium-rgb: 95, 95, 95;
    --ion-color-medium-contrast: ${contrast(medium)};
    --ion-color-medium-contrast-rgb: 255, 255, 255;
    --ion-color-medium-shade: ${Color(medium).darken(shadeRatio)};
    --ion-color-medium-tint: ${Color(medium).lighten(tintRatio)};
    
    --ion-color-light: ${light};
    --ion-color-light-rgb: 246, 248, 252;
    --ion-color-light-contrast: ${contrast(light)};
    --ion-color-light-contrast-rgb: 0, 0, 0;
    --ion-color-light-shade: ${Color(light).darken(shadeRatio)};
    --ion-color-light-tint: ${Color(light).lighten(tintRatio)};`;
}

function contrast(color: any, ratio = 0.8) {
  color = Color(color);
  return color.isDark() ? color.lighten(ratio) : color.darken(ratio);
}
