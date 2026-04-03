---
title: Documentation
permalink: /guides/
---

This section reorganizes the original repository articles under a single landing page.

## HealthChecks UI

- [UI Docker image]({{ '/ui-docker/' | relative_url }})
- [Webhooks and failure notifications]({{ '/webhooks/' | relative_url }})
- [Interface styling and branding]({{ '/styles-branding/' | relative_url }})
- [UI changelog]({{ '/ui-changelog/' | relative_url }})

## Kubernetes

- [Kubernetes operator]({{ '/k8s-operator/' | relative_url }})
- [Automatic Kubernetes service discovery]({{ '/k8s-ui-discovery/' | relative_url }})
- [Liveness and readiness probes]({{ '/kubernetes-liveness/' | relative_url }})

## Recommended reading order

1. Start with the Docker or branding guide if you are wiring the UI into an existing service.
2. Move to the webhook guide when you need alerting integrations such as Teams or Azure Functions.
3. Use the Kubernetes articles when you need discovery, probes, or operator-based deployment.
