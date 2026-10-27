# asteroid_unity

Éviter les asteroïdes !

## Notes de développement

- La méthode `SetShipY(targetY)` du script `AsteroidDodger.cs` permet de déplacer le vaisseau (pour être possiblement contrôlé par un potentiomètre, une photorésistance ou une manette).
- La méthode `GetShipIsVisible()` du script `AsteroidDodger.cs` permet de savoir si le vaisseau est visible (utile pour synchroniser le clignotement d'une DEL avec le vaisseau par exemple).
