import type { Config } from 'tailwindcss'

const config: Config = {
  content: [
    './src/pages/**/*.{js,ts,jsx,tsx,mdx}',
    './src/components/**/*.{js,ts,jsx,tsx,mdx}',
    './src/app/**/*.{js,ts,jsx,tsx,mdx}',
  ],
  theme: {
    extend: {
      backgroundImage: {
        'gradient-radial': 'radial-gradient(var(--tw-gradient-stops))',
        'gradient-conic':
          'conic-gradient(from 180deg at 50% 50%, var(--tw-gradient-stops))',
      },
      fontFamily: {
        'poppins': ['Poppins', 'sans-serif']
      },
      colors: {
        'primaryBlue': {
          50: '#F5F7FD',
          100: '#A3B3E5',
          200: '#B6C6FE',
          300: '#003FFF',
          400: '#264ECA',
        },
        'primaryYellow': {
          100: '#FFDE9B',
          200: '#E4BA2D',
          300: '#F6B612',
        },
        'primaryGreen': {
          100: '#26AF61',
        },
        'primaryGray': {
          50: '#CBD5E0',
          200: '#787486',
          300: '#6C6C77',
          400: '#666666',
          500: '#4B5157',
          600: '#171923',
        },
        'primaryRed': {
          100: '#FFA3AB',
          200: '#FA4A49',
        },
        "darkPrimary": {
          100: '#322E53',
          200: '#282540',
        },
        "darkGray": {
          100: '#E5E7EB',
          200: '#C5E4FC',
          300: '#D9E2FF',
        }
      },
    },
  },
  plugins: [],
}
export default config
